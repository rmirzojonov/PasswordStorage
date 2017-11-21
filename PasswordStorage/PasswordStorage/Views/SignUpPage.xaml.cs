
using PasswordStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordStorage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            string password = passwordEntry.Text;
            string confirm = confirmEntry.Text;
            
            if (!String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(confirm) && password == confirm)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.Auth.SignUp(App.Username, password);
                    Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                messageLabel.Text = "Sign up failed";
            }
        }
    }
}