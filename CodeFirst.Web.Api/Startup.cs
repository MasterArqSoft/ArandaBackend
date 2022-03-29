using CodeFirst.Core;
using CodeFirst.Infrastructure;
using CodeFirst.Infrastructure.Settings;
using CodeFirst.Web.Api.Extensions.App;
using CodeFirst.Web.Api.Extensions.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CodeFirst.Web.Api
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
            //Infraestructura
            services.AddDbContexts(Configuration);
            services.AddRepository();

            //Core
            services.AddCoreLayer();

            //paginacion
            services.AddPaginationExtension(Configuration);

            //Configuracion Swagger
            services.AddSwaggerExtension();

            //Configuracion acceso controlador
            services.AddControllerExtension();

            //Seguridad y procteccion de datos
            services.AddCorsExtension();

            //Salud de los servicios
            services.AddHealthChecks()
                .AddDbContextCheck<CodeFirstContext>("Sql");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension();
            }

            app.UseHealthChecks("/health");

            app.UseHttpsRedirection();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //Routing
            app.UseRouting();

            //CORS
            app.UseCors();

            //Authorization
            app.UseAuthorization();


            //Personalizadas
            app.UseErrorHandlingMiddleware();
            app.UseSerilogRequestLogging();

            //Endpoint Configuration
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/health");
                }
            );
        }
    }
}