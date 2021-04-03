using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Services
{
    public static class JSRuntimeOperation
    {
        public static ValueTask<object> SetItem(this IJSRuntime js, string key, string value)
        {
            return js.InvokeAsync<object>("localStorage.setItem", key, value);
            // localStorage.setItem(key , value)
        }
        public static ValueTask<string> GetItem(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<string>("localStorage.getItem", key);
            // localStorage.getItem(key)
        }
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", key);
        }

    }
}
