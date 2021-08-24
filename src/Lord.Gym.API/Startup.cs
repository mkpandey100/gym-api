using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lord.Gym.Application.Extension;
using Microsoft.OpenApi.Models;
using Lord.Gym.Infrastructure.Extension;
using Lord.Gym.Application.Interfaces;
using Lord.Gym.Application.Implementations;
using System;
using Lord.Gym.API.Extensions;
using Lord.Gym.API.Hubs;

namespace Lord.Gym.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // WebAPI Config
            services.AddControllers();
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.SignalRConfiguration(Configuration);
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() { Title = "CQRS Forum", Version = "v1" });
            });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MessageHub>("/message");
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS Forum v1"));
        }
    }
}