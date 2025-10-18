using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Partify.Application.DTOs.Customers.Validators;
using Partify.Application.ServiceContracts;
using Partify.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
namespace Partify.Application.ServiceRegistration
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            // services.AddTransient<IYourService, YourServiceImplementation>();

            services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CustomerAddDtoValidator>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IDailyFinancialRecordService, DailyFinancialRecordService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            // Additional summary/outstanding services are included in existing supplier/purchase services

            return services;
        }
    }
}
