using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Services
{
    public interface IUserAuthService
    {
        Task Login(string token);
        Task Logout();
    }
}