namespace Presentation
{
    using System.Collections.Generic;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Commands;
    using Business.Detection.Fetching.Commands;
    using Business.Seeds;
    using Data;
    using Data.Detection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.GraphQL.Base;
    using Seeds;

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
            services.AddScoped<Detection.Creating.IResolver, Detection.Creating.Resolver>();
            services.AddScoped<Detection.Fetching.IResolver, Detection.Fetching.Resolver>();
            services.AddScoped<IGetDetection, GetDetection>();
            services.AddScoped<ICreateDetection, CreateDetection>();
            services.AddScoped<IDetectionRepository, DetectionRepository>();
            services.AddScoped<ISeed, Business.Seeds.DetectionSeed>();
            services.AddScoped<IDataFactory, DataFactory>();
        }

        public void Configure(IApplicationBuilder app, Context context, IEnumerable<ISeed> seeds)
        {
            ConfigureEnvironment(app);
            ConfigureDatabase(context);
            ConfigureEndpoints(app);
            foreach (var seed in seeds)
            {
                seed.Execute();
            }
        }

        private void ConfigureEnvironment(IApplicationBuilder app)
        {
            string environmentVariable = _config.GetValue<string>("environment");
            if (environmentVariable == "Default")
            {
                app.UseDeveloperExceptionPage();
            }
        }

        private static void ConfigureEndpoints(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void ConfigureDatabase(Context context) => context.Database.Migrate();
    }
}
