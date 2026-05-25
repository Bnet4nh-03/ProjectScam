using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace ATV_Common_WebAPI.Client_Utility.CSharp.RequestEnco
{
    internal static class CryptoUtils
    {
        internal static (string kxi, byte[] key, byte[] iv) GenerateKxi()
        {
            var key = RandomNumberGenerator.GetBytes(32);
            var iv = RandomNumberGenerator.GetBytes(16);
            var kxi = $"{Base85.Encode(key)}:{Base85.Encode(iv)}";
            return (kxi, key, iv);
        }

        internal static async Task<string> EncryptPayloadAsync(string jsonPayload, byte[] key, byte[] iv)
        {
            // 1. Gzip Compress
            var payloadBytes = Encoding.UTF8.GetBytes(jsonPayload);
            await using var memoryStream = new MemoryStream();
            await using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                await gzipStream.WriteAsync(payloadBytes, 0, payloadBytes.Length);
            }
            var compressedBytes = memoryStream.ToArray();

            // 2. AES Encrypt (CBC, PKCS7)
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var encryptedBytes = encryptor.TransformFinalBlock(compressedBytes, 0, compressedBytes.Length);

            // 3. Base85 Encode
            return Base85.Encode(encryptedBytes);
        }

        internal static async Task<string> DecryptPayloadAsync(string encryptedBase85, string kxi)
        {
            var kxiParts = kxi.Split(':');
            var key = Base85.Decode(kxiParts[0]);
            var iv = Base85.Decode(kxiParts[1]);

            // 1. Base85 Decode
            var encryptedBytes = Base85.Decode(encryptedBase85);

            // 2. AES Decrypt
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var decryptedPaddedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            // 3. Gzip Decompress
            await using var memoryStream = new MemoryStream(decryptedPaddedBytes);
            await using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
            await using var resultStream = new MemoryStream();
            await gzipStream.CopyToAsync(resultStream);
            
            // Use Encoding.UTF8.GetString to handle BOM if present (similar to utf-8-sig in Python)
            return Encoding.UTF8.GetString(resultStream.ToArray());
        }

        internal static JsonElement GetDecryptedBody(string decryptedJson)
        {
            var responseDocument = JsonDocument.Parse(decryptedJson);
            if (responseDocument.RootElement.TryGetProperty("code", out var code) && code.GetInt32() >= 300)
            {
                var message = responseDocument.RootElement.GetProperty("message").GetString();
                throw new HttpRequestException($"API returned an error (Code: {code}): {message}");
            }

            if (responseDocument.RootElement.TryGetProperty("body", out var body))
            {
                return body.Clone(); // Clone to ensure the element is valid after the document is disposed
            }

            // If there is no body, return the root element itself
            return responseDocument.RootElement.Clone();
        }
    }
}