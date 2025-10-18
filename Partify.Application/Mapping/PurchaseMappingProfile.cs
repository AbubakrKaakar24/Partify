using AutoMapper;
using Partify.Application.DTOs.Purchases;
using Partify.Domain.Entities;

namespace Partify.Application.Mapping;

public class PurchaseMappingProfile : Profile
{
    public PurchaseMappingProfile()
    {
        CreateMap<PurchaseAddDto, Purchase>();
        CreateMap<PurchaseUpdateDto, Purchase>();
        CreateMap<Purchase, PurchaseResponseDto>()
            .ForMember(d => d.AmountOwed, o => o.MapFrom(s => s.AmountOwed));
    }
}
