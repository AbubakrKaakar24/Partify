using AutoMapper;
using Partify.Application.DTOs.Customers;
using Partify.Domain.Entities;
namespace Partify.Application.Mapping
{
    public class CustomerMappingProfile:Profile
    {
        public CustomerMappingProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerResponseDto>();
        }

    }
}
