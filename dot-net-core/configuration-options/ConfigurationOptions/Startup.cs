using System;
using System.IO;
using ConfigurationOptions.Configuration;
using ConfigurationOptions.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigurationOptions
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile($"appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower()}.json", optional: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower()}.user.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddControllers();

            services.Configure<APIConfigurations>(Configuration.GetSection(APIConfigurations.Section));
            services.PostConfigure<APIConfigurations>(opt =>
            {
                if (opt.TimeoutInSeconds <= 0)
                    opt.TimeoutInSeconds = 30;
            });

            services.AddSingleton(Configuration);
            services.AddSingleton<ServiceConfiguration>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
