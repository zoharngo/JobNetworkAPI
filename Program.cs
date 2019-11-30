using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using JobNetworkAPI.Data;

namespace JobNetworkAPI
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            var host = CreateHostBuilder(args).Build();
            SeedDB(host);
            host.Run();
        }

        private static void SeedDB(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DBSeeder>();
                seeder.Seed();
            }
            
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
