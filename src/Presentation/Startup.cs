using System;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    
    public class Startup
    {
        private String _connectionString;
        private readonly IConfiguration _config;
        
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("DefaultConnectionString");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _connectionString = _config.GetConnectionString("DefaultConnectionString");
            services.AddDbContext<Context>(options =>
                 options.UseMySQL(_connectionString));
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            String environmentVariable = _config.GetValue<String>("environment");
            if (environmentVariable == "Default")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
            
             app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
             });
        }
    }
}