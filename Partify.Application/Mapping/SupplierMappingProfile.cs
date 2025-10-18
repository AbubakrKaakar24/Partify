using AutoMapper;
using Partify.Application.DTOs.Suppliers;
using Partify.Domain.Entities;

namespace Partify.Application.Mapping;

public class SupplierMappingProfile : Profile
{
    public SupplierMappingProfile()
    {
        CreateMap<SupplierAddDto, Supplier>();
        CreateMap<SupplierUpdateDto, Supplier>();
        CreateMap<Supplier, SupplierResponseDto>();
    }
}
