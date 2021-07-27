namespace Presentation
{
    using System.Collections.Generic;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Fetching.Commands;
    using Business.Camera.Register.Commands;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Commands;
    using Business.Detection.Fetching.Commands;
    using Business.Seeds;
    using Data;
    using Data.Camera;
    using Data.Camera.Filtering;
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
            services.AddScoped<ISeed, Business.Seeds.CameraSeed>();
            services.AddScoped<IDataFactory, DataFactory>();
            services.AddScoped<ICameraRepository, CameraRepository>();
            services.AddScoped<Camera.Register.IResolver, Camera.Register.Resolver>();
            services.AddScoped<IRegisterCamera, RegisterCamera>();
            services.AddScoped<ISeedFilter, SeedFilter>();
            services.AddScoped<ICameraFilter, CameraFilter>();
            services.AddScoped<IGetCamera, GetCamera>();
        }

        public void Configure(IApplicationBuilder app, Context context, IEnumerable<ISeed> seeds)
        {
            ConfigureEnvironment(app);
            ConfigureDatabase(context);
            ConfigureEndpoints(app);
            ConfigureSeeds(seeds);
        }

        private static void ConfigureSeeds(IEnumerable<ISeed> seeds)
        {
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
