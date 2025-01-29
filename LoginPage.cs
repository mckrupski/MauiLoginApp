using System;
using Microsoft.Maui.Controls;
using MauiLoginApp.Services;
using System.Threading.Tasks;

namespace MauiLoginApp.Pages
{
    public class LoginPage : ContentPage
    {
        private Entry emailEntry;
        private Entry passwordEntry;
        private Label tokenLabel;

        public LoginPage()
        {
            emailEntry = new Entry { Placeholder = "E-mail", Keyboard = Keyboard.Email };
            passwordEntry = new Entry { Placeholder = "Hasło", IsPassword = true };
            Button loginButton = new Button { Text = "Zaloguj" };
            tokenLabel = new Label { Text = "" };

            loginButton.Clicked += async (sender, e) => await LoginAsync();

            Content = new VerticalStackLayout
            {
                Padding = new Thickness(20),
                VerticalOptions = LayoutOptions.Center,
                Children = { emailEntry, passwordEntry, loginButton, tokenLabel }
            };
        }

        private async Task LoginAsync()
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Błąd", "Podaj e-mail i hasło", "OK");
                return;
            }

            var apiService = new ApiService();
            var token = await apiService.LoginAsync(email, password);

            if (!string.IsNullOrEmpty(token))
            {
                tokenLabel.Text = "Token: " + token;
                Console.WriteLine($"✅ Otrzymany token: {token}"); // Debugowanie
            }
            else
            {
                await DisplayAlert("Błąd", "Nieprawidłowe dane logowania lub problem z API", "OK");
            }
        }
    }
}
