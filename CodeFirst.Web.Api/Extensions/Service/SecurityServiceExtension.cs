using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst.Web.Api.Extensions.Service
{
    public static class SecurityServiceExtension
    {
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}
