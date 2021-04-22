using Blazor_10.Client.Services;
using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly IHttpService _http;
        private readonly string _URL = "api/users"; 
        public UserRepository(IHttpService http)
        {
            _http = http;
        }
        public async Task<ResponseData<List<Role>>> Roles()
        {
            var result = await _http.Get<List<Role>>($"{_URL}/roles");

            return result;
        }

        public async Task<ResponseData<bool>> CreateUser(User user)
        {
            var result = await _http.PostAsync<User , bool>($"{_URL}/createUser", user);

            return result;
        }
    }
}
