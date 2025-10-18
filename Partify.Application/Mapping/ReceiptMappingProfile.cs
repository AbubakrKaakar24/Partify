using AutoMapper;
using Partify.Application.DTOs.Receipts;
using Partify.Domain.Entities;

namespace Partify.Application.Mapping;

public class ReceiptMappingProfile : Profile
{
    public ReceiptMappingProfile()
    {
        CreateMap<ReceiptAddDto, Receipt>();
        CreateMap<ReceiptUpdateDto, Receipt>();
        CreateMap<Receipt, ReceiptResponseDto>();
    }
}
