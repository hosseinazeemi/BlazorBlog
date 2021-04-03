using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Services
{
    public interface IHttpService
    {
        Task<ResponseData<object>> PostAsync<T>(string url, T data);
        Task<ResponseData<TResponse>> PostAsync<T, TResponse>(string url, T data);

    }
}
