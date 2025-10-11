using Microsoft.Extensions.DependencyInjection;
using Partify.Application.ServiceContracts;
using Partify.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; // Add this if not already present
using AutoMapper;
namespace Partify.Application.ServiceRegistration
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            // services.AddTransient<IYourService, YourServiceImplementation>();

            services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
