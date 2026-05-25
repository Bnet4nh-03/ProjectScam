using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.Common.Middleware
{
    public class EncryptionCompressionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEncryptionService _encryptionService;

        public EncryptionCompressionMiddleware(RequestDelegate next, IEncryptionService encryptionService)
        {
            _next = next;
            _encryptionService = encryptionService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var (shouldProcess, reason) = ShouldProcess(context);
            if (!shouldProcess)
            {
                await _next(context);
                return;
            }

            // Reason 3 is a special case for file downloads (streaming response).
            // It decrypts the request but does not encrypt the response body.
            if (reason == 3)
            {
                await DecryptRequestAsync(context);
                await _next(context); // Let the endpoint write the file stream directly to the response
                return;
            }

            // All other reasons (1 and 2) use the standard encrypted request/response flow.
            await HandleStandardRequest(context, reason);
        }

        private async Task HandleStandardRequest(HttpContext context, int reason)
        {
            // 1. Store original response stream and create a buffer to intercept the response
            var originalResponseBodyStream = context.Response.Body;
            await using var responseBuffer = new MemoryStream();
            context.Response.Body = responseBuffer;

            // 2. Prepare a base response object
            var responseData = CreateBaseResponse();
            string responseContentOriginal = string.Empty;
            int statusCode = StatusCodes.Status200OK;

            try
            {
                // 3. Decrypt the incoming request based on the reason
                if (reason == 1) await DecryptRequestAsync(context);
                else if (reason == 2) await DecryptHeaderForUploadAsync(context, "Set-File-Info");

                // 4. Pass the request to the next middleware/endpoint
                await _next(context);

                // 5. Capture the downstream response content from the buffer
                responseBuffer.Position = 0;
                responseContentOriginal = await new StreamReader(responseBuffer).ReadToEndAsync();
                statusCode = context.Response.StatusCode;
            }
            catch (Exception ex)
            {
                // 6. Map any exceptions to a standard error response
                (statusCode, responseData.message) = HandleRequestException(ex);
            }

            // 7. Generate encryption keys for the response
            var (responseKeyBytes, responseIvBytes, responseKxiString, keyGenError) = GenerateResponseKeys();
            if (!string.IsNullOrEmpty(keyGenError))
            {
                statusCode = StatusCodes.Status500InternalServerError;
                responseData.message = keyGenError;
            }

            // 8. Add the key/iv identifier to the response header
            context.Response.Headers.Append("kxi", responseKxiString);

            // 9. Parse the original response from the endpoint into the 'body' of our standard response
            if (!string.IsNullOrEmpty(responseContentOriginal))
            {
                TryParseResponseBody(responseData, responseContentOriginal);
            }

            // 10. Set the final response code and content type
            responseData.code = statusCode;
            context.Response.StatusCode = StatusCodes.Status200OK; // The HTTP status is always 200 for encrypted responses
            context.Response.ContentType = "text/plain";

            // 11. Encrypt the final response payload
            var encryptedResponse = EncryptResponse(responseData, responseKeyBytes, responseIvBytes);

            // 12. Write the encrypted payload to the original response stream
            await WriteEncryptedResponseAsync(originalResponseBodyStream, encryptedResponse);
        }

        /// <summary>
        /// Checks if the middleware should process this request.
        /// </summary>
        private (bool, int) ShouldProcess(HttpContext context)
        {
            var path = context.Request.Path.ToString();

            if (HttpMethods.IsOptions(context.Request.Method))
            {
                return (false, 0);
            }

            if (path.StartsWith("/Common/Data_Method/DB_EnCo", StringComparison.OrdinalIgnoreCase) ||
                path.StartsWith("/Common/File_Method/File_Ops", StringComparison.OrdinalIgnoreCase) ||
                path.StartsWith("/Common/Email_EnCo", StringComparison.OrdinalIgnoreCase)
                )
            {
                return (true, 1); // Decrypt/encrypt request and response json
            }

            if (path.StartsWith("/Common/File_Method/Set", StringComparison.OrdinalIgnoreCase))
            {
                return (true, 2); // Decrypt specific form-data and encrypt response json
            }

            if (path.StartsWith("/Common/File_Method/Get", StringComparison.OrdinalIgnoreCase))
            {
                return (true, 3); // Decrypt request body only, response have no encrypt
            }

            return (false, 0);
        }

        /// <summary>
        /// Creates a base response object with default values.
        /// </summary>
        private Common.Models.BaseModel.BaseResponse CreateBaseResponse()
        {
            return new Common.Models.BaseModel.BaseResponse
            {
                code = 200,
                message = "OK"
            };
        }

        /// <summary>
        /// Decrypts the incoming request body using the provided kxi header.
        /// </summary>
        private async Task DecryptRequestAsync(HttpContext context)
        {
            // Validate Content-Type
            var mediaType = context.Request.ContentType?.Split(';')[0]?.Trim();
            if (!string.Equals(mediaType, "text/plain", StringComparison.OrdinalIgnoreCase))
                throw new NotSupportedException("Content-Type not correct. Expected text/plain.");

            // Extract kxi header
            if (!context.Request.Headers.TryGetValue("kxi", out var kxiHeader))
                throw new ArgumentException("Missing kxi header.");

            var kxiParts = kxiHeader.ToString().Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (kxiParts.Length != 2)
                throw new FormatException("Invalid kxi header format. Expected 'key:iv'.");

            // Decode key and IV
            var keyBytes = Base85.Decode(kxiParts[0]);
            var ivBytes = Base85.Decode(kxiParts[1]);

            if (keyBytes.Length != 32 || ivBytes.Length != 16)
                throw new ArgumentException("Decoded key or IV has incorrect length.");

            // Read and decrypt request body
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var encryptedBody = await reader.ReadToEndAsync();
            var decryptedBody = _encryptionService.Decrypt(encryptedBody, keyBytes, ivBytes);

            // Replace request body with decrypted JSON
            var newRequestBodyStream = new MemoryStream(Encoding.UTF8.GetBytes(decryptedBody));
            context.Request.Body = newRequestBodyStream;
            context.Request.ContentLength = newRequestBodyStream.Length;
            context.Request.ContentType = "application/json";
        }

        private Task DecryptHeaderForUploadAsync(HttpContext context, string headerName)
        {
            // Validate Content-Type
            var mediaType = context.Request.ContentType?.Split(';')[0]?.Trim();
            if (!string.Equals(mediaType, "multipart/form-data", StringComparison.OrdinalIgnoreCase))
                throw new NotSupportedException("Content-Type not correct. Expected multipart/form-data.");

            // Extract kxi header
            if (!context.Request.Headers.TryGetValue("kxi", out var kxiHeader))
                throw new ArgumentException("Missing kxi header.");

            var kxiParts = kxiHeader.ToString().Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (kxiParts.Length != 2)
                throw new FormatException("Invalid kxi header format. Expected 'key:iv'.");

            // Decode key and IV
            var keyBytes = Base85.Decode(kxiParts[0]);
            var ivBytes = Base85.Decode(kxiParts[1]);

            if (keyBytes.Length != 32 || ivBytes.Length != 16)
                throw new ArgumentException("Decoded key or IV has incorrect length.");

            // Extract and decrypt the custom header
            if (!context.Request.Headers.TryGetValue(headerName, out var encryptedHeaderValue))
                throw new ArgumentException($"Missing {headerName} header.");

            var decryptedSetFileInfo = _encryptionService.Decrypt(encryptedHeaderValue, keyBytes, ivBytes);

            // Place the decrypted info in HttpContext.Items to be used by the endpoint.
            context.Items["DecryptedSetFileInfo"] = decryptedSetFileInfo;

            return Task.CompletedTask;
        }

        /// <summary>
        /// Maps exceptions to HTTP status codes and messages.
        /// </summary>
        private (int statusCode, string message) HandleRequestException(Exception ex)
        {
            return ex switch
            {
                ArgumentException => (StatusCodes.Status400BadRequest, $"Bad Request: {ex.Message}"),
                FormatException => (StatusCodes.Status400BadRequest, $"Bad Request: {ex.Message}"),
                NotSupportedException => (StatusCodes.Status415UnsupportedMediaType, $"Unsupported Media Type: {ex.Message}"),
                _ => (StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}")
            };
        }

        /// <summary>
        /// Generates a random encryption key and IV for the response.
        /// </summary>
        private (byte[] key, byte[] iv, string kxiString, string error) GenerateResponseKeys()
        {
            try
            {
                var kxiString = EncryptionService.GenerateRandomKxi();
                var parts = kxiString.Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    throw new InvalidOperationException("Generated kxi string is malformed.");

                var key = Base85.Decode(parts[0]);
                var iv = Base85.Decode(parts[1]);

                if (key.Length != 32 || iv.Length != 16)
                    throw new InvalidOperationException("Decoded generated key or IV has incorrect length.");

                return (key, iv, kxiString, null);
            }
            catch (Exception ex)
            {
                return (null, null, "error_generating_kxi", $"Internal Server Error: Failed to generate response encryption keys: {ex.Message}");
            }
        }

        /// <summary>
        /// Attempts to parse the original response body as JSON.
        /// </summary>
        private void TryParseResponseBody(Common.Models.BaseModel.BaseResponse responseData, string content)
        {
            try
            {
                responseData.body = JsonDocument.Parse(content).RootElement;
            }
            catch (JsonException)
            {
                responseData.message = string.IsNullOrEmpty(responseData.message)
                    ? "Endpoint returned non-JSON response"
                    : responseData.message + " | Endpoint returned non-JSON response";
            }
        }

        /// <summary>
        /// Encrypts the final response payload.
        /// </summary>
        private string EncryptResponse(Common.Models.BaseModel.BaseResponse responseData, byte[] key, byte[] iv)
        {
            try
            {
                return _encryptionService.Encrypt(JsonSerializer.Serialize(responseData), key, iv);
            }
            catch (Exception ex)
            {
                responseData.code = StatusCodes.Status500InternalServerError;
                responseData.message = $"Internal Server Error: Failed to encrypt response data: {ex.Message}";
                responseData.body = null;
                return string.Empty;
            }
        }

        /// <summary>
        /// Writes the encrypted response to the output stream.
        /// </summary>
        private async Task WriteEncryptedResponseAsync(Stream outputStream, string encryptedContent)
        {
            var bytes = Encoding.UTF8.GetBytes(encryptedContent);
            await outputStream.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}