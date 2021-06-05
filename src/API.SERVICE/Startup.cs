using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace API.SERVICE
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //c.AddSecurityDefinition("a", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OpenIdConnect,
                //    OpenIdConnectUrl = new Uri("")
                //});
                c.DocumentFilter<SecretApiFilter>();
                c.SwaggerDoc("v1-secret", new OpenApiInfo
                {
                    Title = "Secret AspNetCoreApi",
                    Version = "v1"
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AspNetCoreApi",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region V1 
            /*
            app.Use(async (httpContext, next) => {
                if (
                    (httpContext.Request.Headers.TryGetValue("X-Forwarded-Host", out var fwd) && fwd.Equals("localhost:5050")) // is  not internal call
                    && httpContext.Request.Path.HasValue && httpContext.Request.Path.Value.Contains("-secret/swagger.json")
                )
                {

                    Console.WriteLine(fwd);
                    httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                }
                else
                {
                    await next();
                }
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "public/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/public/swagger/v1-secret/swagger.json", "My API - V1 Secret");
                c.SwaggerEndpoint("/public/swagger/v1/swagger.json", "My API - V1 Public");
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "public/swagger";
                // c.SwaggerEndpoint("/public/swagger/v1/swagger.json", "My API - V1 Public");
                c.SwaggerEndpoint("http://localhost:5050/my-path/swagger/v1/swagger.json", "My API - V1 Public");
            });
            */
            #endregion

            #region V2
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1-secret/swagger.json", "My API - V1 Secret");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API - V1 Public");
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "public-swagger";
                c.SwaggerEndpoint("http://localhost:5050/my-path/swagger/v1/swagger.json", "My API - V1 Public");
            });
            
            #endregion

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
