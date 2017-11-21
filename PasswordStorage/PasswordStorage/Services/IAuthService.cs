using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStorage.Services
{
    public interface IAuthService
    {
        bool SaveCredentials(string UserName, string Password);
        string UserName { get; }
        string Password { get; }
    }
}
