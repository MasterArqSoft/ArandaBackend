using CodeFirst.Core.Features.ProductService;
using CodeFirst.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CodeFirst.Core
{
    public static class ServiceRegistration
    {
        public static void AddCoreLayer(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}