using Blazor_10.Server.Context;
using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _db;
        public AuthController(IConfiguration config, AppDbContext db)
        {
            _config = config;
            _db = db;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<TokenData>> CreateUser([FromBody] UserData userData)
        {
            var user = new IdentityUser { UserName = userData.Email, Email = userData.Email };
            bool result = false;
            // Send User Data to Repository for add
            if (result)
            {
                return GenerateToken(userData);
            }
            else
            {
                return BadRequest("UserName Or Password Is Invalid");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenData>> LoginUser([FromBody] UserData userData)
        {
            User response = _db.Users.FirstOrDefault(p => p.Email == userData.Email);
            bool result = true;
            if (result)
            {
                return GenerateToken(response);
            }
            else
            {
                return BadRequest("Invalid");
            }
        }
        private TokenData GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.Name),
                new Claim(ClaimTypes.Email , user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: cred
            );

            return new TokenData
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
