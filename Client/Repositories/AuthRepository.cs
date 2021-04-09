using Blazor_10.Client.Services;
using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IHttpService _httpService;
        private readonly string authUrl = "api/auth";
        public AuthRepository(IHttpService http)
        {
            _httpService = http;
        }
        public async Task<TokenData> Login(UserData userData)
        {
            var response = await _httpService.PostAsync<UserData, TokenData>($"{authUrl}/login", userData);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}