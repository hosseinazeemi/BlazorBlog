using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Blazor_10.Client.Services
{
    public class GenerateNewToken
    {
        [CascadingParameter] public Task<AuthenticationState> AuthenticationState { get; set; }
        public GenerateNewToken(IUserAuthService loginService)
        {
            _loginService = loginService;
        }

        Timer timer;
        private readonly IUserAuthService _loginService;

        public void Initiate()
        {
            timer = new Timer();
            timer.Interval = 10000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!await _loginService.CheckToken())
            {
                await _loginService.CleanUp();
                Dispose();
            }
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
