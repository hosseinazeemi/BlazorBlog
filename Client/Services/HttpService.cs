using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor_10.Client.Services
{
    public class HttpService : IHttpService
    {
        JsonSerializerOptions defaultJsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true ,
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        private readonly HttpClient _http;
        public HttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseData<object>> PostAsync<T>(string url, T data)
        {
            var dataSerialize = System.Text.Json.JsonSerializer.Serialize(data);
            var content = new StringContent(dataSerialize, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, content);

            return new ResponseData<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<ResponseData<TResponse>> PostAsync<T, TResponse>(string url, T data)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(data);
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
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }
        public async Task<ResponseData<T>> Get<T>(string url)
        {
            var responseHTTP = await _http.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHTTP, defaultJsonSerializerOptions);
                return new ResponseData<T>(response, true, responseHTTP);
            }
            else
            {
                return new ResponseData<T>(default, false, responseHTTP);
            }
        }
        
    }
}