using System;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Presentation
{
    
    public class Startup
    {
        
        public string ConnectionString { get; set; }
        private readonly IConfiguration _config;
        
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }
        
       
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(ConnectionString));
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