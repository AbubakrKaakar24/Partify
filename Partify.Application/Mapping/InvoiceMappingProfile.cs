using AutoMapper;
using Partify.Application.DTOs.Invoices;
using Partify.Domain.Entities;

namespace Partify.Application.Mapping;

public class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceAddDto, Invoice>();
        CreateMap<InvoiceUpdateDto, Invoice>();
        CreateMap<Invoice, InvoiceResponseDto>();
    }
}
