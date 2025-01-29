using Microsoft.Maui.Controls;
using MauiLoginApp.Pages;

namespace MauiLoginApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }
    }
}
