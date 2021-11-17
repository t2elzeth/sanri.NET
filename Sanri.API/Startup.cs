using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sanri.API.Extensions;
using Sanri.API.Validation;

namespace Sanri.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Enable CORS
            services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

            services.AddMvcCore()
                    .UseCustomModelValidation()
                    .AddFluentValidation(config =>
                    {
                        config.ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;
                        config.DisableDataAnnotationsValidation      = true;
                        config.ImplicitlyValidateChildProperties     = true;
                        config.RegisterValidatorsFromAssembly(Assembly.Load("Sanri.API"));
                    });

            
            // JSON Serializer
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                                           options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                    .AddNewtonsoftJson(options =>
                                           options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddControllers();
            services.AddSingleton(NhSessionFactory.Instance);

            services.AddSwaggerGen(c => //
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Sanri.API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sanri.API v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}