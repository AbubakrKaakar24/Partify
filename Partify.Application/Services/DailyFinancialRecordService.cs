using AutoMapper;
using Partify.Application.Common;
using Partify.Application.DTOs.DailyFinancialRecords;
using Partify.Application.ServiceContracts;
using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts.Base;

namespace Partify.Application.Services;

public class DailyFinancialRecordService : IDailyFinancialRecordService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DailyFinancialRecordService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<DailyFinancialRecordResponseDto>> CreateRecord(DailyFinancialRecordAddDto record)
    {
        var entity = _mapper.Map<DailyFinancialRecord>(record);
        await _unitOfWork.DailyFinancialRecordRepository.Add(entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<DailyFinancialRecordResponseDto>.SuccessResult(_mapper.Map<DailyFinancialRecordResponseDto>(entity));
    }

    public async Task<Result<DailyFinancialRecordResponseDto>> DeleteRecord(int id)
    {
        var entity = await _unitOfWork.DailyFinancialRecordRepository.GetById(id);
        await _unitOfWork.DailyFinancialRecordRepository.Delete(entity!);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<DailyFinancialRecordResponseDto>.SuccessResult(_mapper.Map<DailyFinancialRecordResponseDto>(entity));
    }

    public async Task<Result<DailyFinancialRecordResponseDto>> GetRecordById(int id)
    {
        var entity = await _unitOfWork.DailyFinancialRecordRepository.GetById(id);
        return Result<DailyFinancialRecordResponseDto>.SuccessResult(_mapper.Map<DailyFinancialRecordResponseDto>(entity));
    }

    public async Task<Result<IEnumerable<DailyFinancialRecordResponseDto>>> GetRecords()
    {
        var entities = await _unitOfWork.DailyFinancialRecordRepository.GetAll();
        var mapped = _mapper.Map<IEnumerable<DailyFinancialRecordResponseDto>>(entities);
        return Result<IEnumerable<DailyFinancialRecordResponseDto>>.SuccessResult(mapped);
    }

    public async Task<Result<DailyFinancialRecordResponseDto>> UpdateRecord(int id, DailyFinancialRecordUpdateDto record)
    {
        var entity = await _unitOfWork.DailyFinancialRecordRepository.GetFirstOrDefault(r => r.Id == id);
        _mapper.Map(record, entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<DailyFinancialRecordResponseDto>.SuccessResult(_mapper.Map<DailyFinancialRecordResponseDto>(entity));
    }

    public async Task<Result<DailyFinancialSummaryDto>> GetSummary(DateTimeOffset from, DateTimeOffset to)
    {
        if (to < from)
        {
            return Result<DailyFinancialSummaryDto>.FailureResult("InvalidRange", "'to' must be greater than or equal to 'from'");
        }
        var records = await _unitOfWork.DailyFinancialRecordRepository.GetAll(r => r.Date >= from && r.Date <= to);
        if (!records.Any())
        {
            return Result<DailyFinancialSummaryDto>.EmptyResult("DailyFinancialRecord");
        }
        var summary = new DailyFinancialSummaryDto
        {
            From = from,
            To = to,
            TotalRevenue = records.Sum(r => r.Revenue),
            TotalExpenses = records.Sum(r => r.Expenses),
            TotalProfit = records.Sum(r => r.Profit),
            RecordCount = records.Count
        };
        return Result<DailyFinancialSummaryDto>.SuccessResult(summary);
    }
}
