﻿using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blazor_10.Client.Services
{
    public class UserStateService
    {
        public UserStateData user { get; set; }
        public UserStateData GetUserInfo()
        {
            return user;
        }

        public void SetUserInfo(IEnumerable<Claim> claims)
        {
            user = new UserStateData
            {
                Email = claims.Where(p => p.Type == ClaimTypes.Email).Select(c => c.Value).FirstOrDefault() , 
                RoleName = claims.Where(p => p.Type == ClaimTypes.Role).Select(c => c.Value).FirstOrDefault() , 
                FirstName = claims.Where(p => p.Type == "FirstName").Select(c => c.Value).FirstOrDefault() , 
                LastName = claims.Where(p => p.Type == "LastName").Select(c => c.Value).FirstOrDefault(),  
                Id = claims.Where(p => p.Type == "UserId").Select(c => c.Value).FirstOrDefault()  
            };
        }
    }
}
