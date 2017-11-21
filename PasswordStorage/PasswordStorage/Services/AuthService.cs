using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace PasswordStorage.Services
{
    public class AuthService : IAuthService
    {
        public string UserName
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }
        public string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }
        public bool IsUserLoggedIn
        {
            get; private set;
        }
        public Dictionary<string, string> CustomPasswords
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                if (account != null)
                {
                    var dict = account.Properties.Where(p => p.Key != "Password");
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    foreach(var d in dict)
                    {
                        result.Add(d.Key, d.Value);
                    }
                    return result;
                }
                else
                    return null;
            }
        }

        public bool Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(password) && password == Password)
            {
                IsUserLoggedIn = true;
                return true;
            }
            return false;
        }
        public void Logout()
        {
            IsUserLoggedIn = false;
        }
        public bool SignUp(string userName, string password)
        {
            if (SaveCredentials(userName, password))
            {
                IsUserLoggedIn = true;
                return true;
            }
            return false;
        }
        public bool SaveCredentials(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                Account account = new Account
                {
                    Username = userName
                };
                account.Properties.Add("Password", password);
                AccountStore.Create().Save(account, App.AppName);
                return true;
            }
            return false;
        }
    }
}
