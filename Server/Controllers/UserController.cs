using Blazor_10.Server.Context;
using Blazor_10.Shared.DTO;
using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = _protect.HashPassword(user.Password);
            }

            _appDbContext.Users.Add(user);

            await _appDbContext.SaveChangesAsync();

            return true;
        }
        [HttpPost("registerUser")]
        public async Task<bool> RegisterUser([FromBody] RegisterDTO user)
        {
            var role = _appDbContext.Roles.FirstOrDefault(p => p.EnCaption == "user");
            User newUser = new User
            {
                Name = user.Name , 
                LastName = user.LastName , 
                Email = user.Email , 
                RoleId = 1
                
            };
            if (!string.IsNullOrEmpty(user.Password))
            {
                newUser.Password = _protect.HashPassword(user.Password);
            }

            _appDbContext.Users.Add(newUser);

            await _appDbContext.SaveChangesAsync();

            return true;
        }

        [HttpGet("userList")]
        public async Task<List<User>> GetUsers()
        {
            var users = _appDbContext.Users.OrderByDescending(p => p.Id).ToList();

            return await Task.FromResult(users);
        }

        [HttpPost("getUserById")]
        public async Task<User> GetUserById([FromBody] long Id)
        {
            var result = _appDbContext.Users.Where(p => p.Id == Id).FirstOrDefault();

            if (result != null)
            {
                return await Task.FromResult(result);
            }else
            {
                return await Task.FromResult(new User());
            }
        }

        [HttpPost("updateUser")]
        public async Task<bool> UpdateUser([FromBody]User user)
        {
            _appDbContext.Users.Update(user);
            
            try
            {
                await _appDbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        [HttpPost("deleteUser")]
        public async Task<bool> DeleteUser([FromBody]User user)
        {
            _appDbContext.Users.Remove(user);

            try
            {
                await _appDbContext.SaveChangesAsync();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
