using Blazor_10.Server.Context;
using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        private readonly AppDbContext _appDbContext;
        private readonly ProtectPassword _protect;
        public UserController(AppDbContext appDb , ProtectPassword protect)
        {
            _appDbContext = appDb;
            _protect = protect;
        }

        [HttpGet("roles")]
        public async Task<List<Role>> Roles()
        {
            var result = _appDbContext.Roles.ToList();
            if (result != null && result.Count > 0)
            {
                return await Task.FromResult(result);
            }else
            {
                return await Task.FromResult(new List<Role>());
            }
        }

        [HttpPost("createUser")]
        public async Task<bool> CreateUser([FromBody] User user)
        {
            user.Password = _protect.HashPassword(user.Password);
            _appDbContext.Users.Add(user);

            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}
