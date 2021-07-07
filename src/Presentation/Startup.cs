using System;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.GraphQL.Base;

namespace Presentation
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config) => _config = config;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _config.GetSection("Database").GetValue<string>("ConnectionString");

            services.AddDbContext<Context>(options => options.UseMySQL(connectionString));
            services.AddControllers();

            services.AddScoped<Schema>();
        }

        public void Configure(IApplicationBuilder app, Context dbContext)
        {
            VerifyEnvironment(app);
            AddInDatabase(dbContext);
            MakeRouteEndpoints(app);
        }

        private void VerifyEnvironment(IApplicationBuilder app)
        {
            String environmentVariable = _config.GetValue<String>("environment");
            if (environmentVariable == "Default")
            {
                app.UseDeveloperExceptionPage();
            }
        }

        private void MakeRouteEndpoints(IApplicationBuilder app)
        {
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

        private void AddInDatabase(Context dbContext)
        {
            dbContext.Database.EnsureCreated();
            dbContext.Add(new EDetections {Name = "name"});
            dbContext.SaveChanges();
        }
    }
}
