using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.Client_Utility.CSharp.RequestEnco
{
    public class EncryptedSqlApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public EncryptedSqlApiClient(string apiBaseUrl)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = apiBaseUrl;
        }

        public async Task<JsonElement> CallSpAsync(object payload)
        {
            // Console.WriteLine("\n--- Calling Stored Procedure (/Call_SP) ---"); // Removed console output for GUI app
            return await SendEncryptedRequestAsync($"{_apiBaseUrl}/Common/Data_Method/DB_EnCo/Call_SP", payload);
        }

        public async Task<JsonElement> CallScAsync(object payload)
        {
            // Console.WriteLine("\n--- Calling SQL Command (/Call_SC) ---"); // Removed console output for GUI app
            return await SendEncryptedRequestAsync($"{_apiBaseUrl}/Common/Data_Method/DB_EnCo/Call_SC", payload);
        }

        private async Task<JsonElement> SendEncryptedRequestAsync(string url, object payload)
        {
            // 1. Prepare and encrypt request payload
            var (reqKxi, reqKey, reqIv) = CryptoUtils.GenerateKxi();
            var encryptedPayload = await CryptoUtils.EncryptPayloadAsync(JsonSerializer.Serialize(payload), reqKey, reqIv);

            // 2. Send request
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Content = new StringContent(encryptedPayload, Encoding.UTF8, "text/plain");
            requestMessage.Headers.Add("kxi", reqKxi);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            // 3. Process encrypted response
            var responseKxi = response.Headers.GetValues("kxi").First();
            var encryptedBody = await response.Content.ReadAsStringAsync();
            var decryptedJson = await CryptoUtils.DecryptPayloadAsync(encryptedBody, responseKxi);

            // Console.WriteLine("Request successful."); // Removed console output for GUI app
            return CryptoUtils.GetDecryptedBody(decryptedJson);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}