using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json; // Dodaj tę bibliotekę

namespace MauiLoginApp.Services
{
    public class ApiService
    {
        private const string ApiUrl = "https://reqres.in/api/login"; // Testowe API

        public async Task<string> LoginAsync(string email, string password)
        {
            using HttpClient client = new HttpClient();

            var payload = new { email, password };
            var jsonPayload = JsonConvert.SerializeObject(payload); // Serializacja JSON
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ApiUrl, content);
            string responseText = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"📡 API Response: {responseText}"); // 🔍 Debugowanie odpowiedzi

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TokenResponse>(responseText);
                return result?.Token;
            }

            return null;
        }
    }

    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
