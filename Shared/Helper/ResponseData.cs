using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Helper
{
    public class ResponseData<T>
    {
        public ResponseData(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            Success = success;
            Response = response;
            HttpResponse = httpResponseMessage;
        }

        public bool Success { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }

        public async Task<string> GetBody()
        {
            return await HttpResponse.Content.ReadAsStringAsync();
        }
    }
}
