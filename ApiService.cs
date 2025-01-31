using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json; // Dodaj tę bibliotekę

namespace MauiLoginApp.Services
{
    public class ApiService
    {
        public async Task<string> LoginAsync(string email, string password)
        {
            // Symulacja opóźnienia połączenia z API
            await Task.Delay(1000);

            // Sprawdź, czy dane logowania są poprawne
            if (email == "maks.kr@teb.com" && password == "tebubikacja")
            {
                // Zwróć symulowany token
                return "1234567goatmakskrupski";
            }

            // Jeśli dane logowania są nieprawidłowe, zwróć null
            return null;
        }
    }

    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
