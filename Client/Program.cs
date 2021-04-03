using Blazor_10.Client.Repositories;
using Blazor_10.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            builder.Services.AddScoped<JWTService>();
            builder.Services.AddScoped<AuthenticationStateProvider, JWTService>(
                option => option.GetRequiredService<JWTService>()    
            );
            builder.Services.AddScoped<IUserAuthService, JWTService>(
                option => option.GetRequiredService<JWTService>()    
            );


            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();

            await builder.Build().RunAsync();
        }
    }
}
