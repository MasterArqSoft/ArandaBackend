using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace CodeFirst.Web.Api.Extensions.Service
{
    public static class SwaggerServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Architecture - WebApi",
                    Description = "Esta API será responsable de la distribución y autorización general de los datos.",
                    Contact = new OpenApiContact
                    {
                        Name = "Erwing Candelario Restrepo",
                        Email = "ingeniero_79@Hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/ecandelario/"),
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}