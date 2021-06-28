using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Presentation
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddJsonFile("Settings/settings.default.json");
                    config.AddEnvironmentVariables("HERMES_API_");
                })
                .ConfigureWebHostDefaults(webBuilder =>  webBuilder.UseStartup<Startup>()); 
    }
}