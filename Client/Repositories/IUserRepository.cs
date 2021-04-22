using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseData<bool>> CreateUser(User user);
        Task<ResponseData<List<Role>>> Roles();
    }
}
