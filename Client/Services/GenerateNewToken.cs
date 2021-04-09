using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Blazor_10.Client.Services
{
    public class GenerateNewToken
    {

        public GenerateNewToken(IUserAuthService loginService)
        {
            this.loginService = loginService;
        }

        Timer timer;
        private readonly IUserAuthService loginService;

        public void Initiate()
        {
            timer = new Timer();
            timer.Interval = 1000 * 60 * 60; // 4 minutes
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("timer elapsed");
            //loginService.TryRenewToken();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
