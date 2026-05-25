using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.Client_Utility.CSharp.RequestEnco
{
    public class EncryptedFileApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public EncryptedFileApiClient(string apiBaseUrl)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = apiBaseUrl;
        }

        // --- Public API Methods ---

        public async Task<JsonElement> UploadFileAsync(string localFilePath, string saveMode = "Rename", string appName = "CSharpTestClient")
        {
            // Console.WriteLine($"\n--- Uploading file: {localFilePath} ---"); // Removed console output for GUI app
            var fileInfo = new FileInfo(localFilePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File to upload not found", localFilePath);
            }

            var metadata = new
            {
                AppName = appName,
                SaveMode = saveMode,
                FileName = fileInfo.Name,
                FileSize = fileInfo.Length
            };

            var (reqKxi, reqKey, reqIv) = CryptoUtils.GenerateKxi();
            var encryptedMetadata = await CryptoUtils.EncryptPayloadAsync(JsonSerializer.Serialize(metadata), reqKey, reqIv);

            using var formData = new MultipartFormDataContent();
            using var fileStream = new StreamContent(fileInfo.OpenRead());
            fileStream.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            formData.Add(fileStream, "file", fileInfo.Name);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_apiBaseUrl}/Common/File_Method/Set");
            requestMessage.Content = formData;
            requestMessage.Headers.Add("kxi", reqKxi);
            requestMessage.Headers.Add("Set-File-Info", encryptedMetadata);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var responseKxi = response.Headers.GetValues("kxi").First();
            var encryptedBody = await response.Content.ReadAsStringAsync();
            var decryptedJson = await CryptoUtils.DecryptPayloadAsync(encryptedBody, responseKxi);

            // Console.WriteLine("Upload successful."); // Removed console output for GUI app
            return CryptoUtils.GetDecryptedBody(decryptedJson);
        }

        public async Task DownloadFileAsync(string remoteFilePath, string localSavePath)
        {
            // Console.WriteLine($"\n--- Downloading file: {remoteFilePath} ---"); // Removed console output for GUI app
            var payload = new { filePath = remoteFilePath };
            var (reqKxi, reqKey, reqIv) = CryptoUtils.GenerateKxi();
            var encryptedPayload = await CryptoUtils.EncryptPayloadAsync(JsonSerializer.Serialize(payload), reqKey, reqIv); // Corrected line

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_apiBaseUrl}/Common/File_Method/Get");
            requestMessage.Content = new StringContent(encryptedPayload, Encoding.UTF8, "text/plain");
            requestMessage.Headers.Add("kxi", reqKxi);

            var response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            using var fileStream = new FileStream(localSavePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await responseStream.CopyToAsync(fileStream);

            // Console.WriteLine($"Download successful. Saved to: {localSavePath}"); // Removed console output for GUI app
        }

        public async Task<JsonElement> FileOperationAsync(object payload)
        {
            // Console.WriteLine("\n--- Performing File Operation ---"); // Removed console output for GUI app
            var (reqKxi, reqKey, reqIv) = CryptoUtils.GenerateKxi();
            var encryptedPayload = await CryptoUtils.EncryptPayloadAsync(JsonSerializer.Serialize(payload), reqKey, reqIv);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_apiBaseUrl}/Common/File_Method/File_Ops");
            requestMessage.Content = new StringContent(encryptedPayload, Encoding.UTF8, "text/plain");
            requestMessage.Headers.Add("kxi", reqKxi);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var responseKxi = response.Headers.GetValues("kxi").First();
            var encryptedBody = await response.Content.ReadAsStringAsync();
            var decryptedJson = await CryptoUtils.DecryptPayloadAsync(encryptedBody, responseKxi);

            // Console.WriteLine("File operation successful."); // Removed console output for GUI app
            return CryptoUtils.GetDecryptedBody(decryptedJson);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}