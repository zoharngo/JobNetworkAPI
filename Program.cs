using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JobNetworkAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(SetupConfgiuration);
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfgiuration(WebHostBuilderContext ctx, IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Sources.Clear();
            configurationBuilder.AddJsonFile("config.json", false, true).AddEnvironmentVariables();
        }
    }
}
