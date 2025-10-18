using AutoMapper;
using Partify.Application.DTOs.DailyFinancialRecords;
using Partify.Domain.Entities;

namespace Partify.Application.Mapping;

public class DailyFinancialRecordMappingProfile : Profile
{
    public DailyFinancialRecordMappingProfile()
    {
        CreateMap<DailyFinancialRecordAddDto, DailyFinancialRecord>();
        CreateMap<DailyFinancialRecordUpdateDto, DailyFinancialRecord>();
        CreateMap<DailyFinancialRecord, DailyFinancialRecordResponseDto>();
    }
}
