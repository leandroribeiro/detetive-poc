using Detetive.Domain.Repositories;
using Detetive.Infrastructure;
using Detetive.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Detetive.WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DetetiveContext>(_ => new DetetiveContext(Configuration.GetConnectionString("DetetiveContext")));

            // Add framework services.
            services.AddMvc();

            services.AddTransient<IArmaRepository, ArmaRepository>();
            services.AddTransient<ILocalRepository, LocalRepository>();
            services.AddTransient<ISuspeitoRepository, SuspeitoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            // CORS
            // https://docs.asp.net/en/latest/security/cors.html
            app.UseCors(builder =>
                    builder.WithOrigins("http://localhost:3000", "http://localhost:5000", "http://www.myclientserver.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod());

            app.UseMvc();
        }
    }
}
