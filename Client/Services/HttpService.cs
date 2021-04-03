using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor_10.Client.Services
{
    public class HttpService:IHttpService
    {
        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private readonly HttpClient _http;
        public HttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseData<object>> PostAsync<T>(string url, T data)
        {
            var dataSerialize = JsonSerializer.Serialize(data);
            var content = new StringContent(dataSerialize, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, content);

            return new ResponseData<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<ResponseData<TResponse>> PostAsync<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerializerOptions);
                return new ResponseData<TResponse>(responseDeserialized, true, response);
            }
            else
            {
                return new ResponseData<TResponse>(default, false, response);
            }
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
