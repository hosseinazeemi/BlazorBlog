using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Repositories
{
    public interface IAuthRepository
    {
        Task<TokenData> Login(UserData userData);
    }
}
