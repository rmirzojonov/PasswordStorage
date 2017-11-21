using PasswordStorage.Services;
using PasswordStorage.Views;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PasswordStorage
{
    public partial class App : Application
    {
        public static string AppName { get { return "App"; } }
        public static AuthService Auth { get; private set; }
        public static string Username { get; private set; } = "Default";

        public App()
        {
            Auth = new AuthService();
            InitializeComponent();
            if (!Auth.IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }
    }
}