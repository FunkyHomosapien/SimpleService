using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SimpleService.Services;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace SimpleService
{

    [ExcludeFromCodeCoverage]
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<IApplicationHealthService, ApplicationHealthService>();
            services.AddSingleton<IServerHealthService, ServerHealthService>();
            services.AddSingleton<IDatabaseHealthService, DatabaseHealthService>();

            services.AddSingleton(Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .CreateLogger()
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Simple Service API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Service API");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Please provide a valid route!");
            });
        }
    }
}
