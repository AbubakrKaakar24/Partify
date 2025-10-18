using Partify.Application.Common;
using Partify.Application.DTOs.DailyFinancialRecords;

namespace Partify.Application.ServiceContracts;

public interface IDailyFinancialRecordService
{
    Task<Result<IEnumerable<DailyFinancialRecordResponseDto>>> GetRecords();
    Task<Result<DailyFinancialRecordResponseDto>> GetRecordById(int id);
    Task<Result<DailyFinancialRecordResponseDto>> CreateRecord(DailyFinancialRecordAddDto record);
    Task<Result<DailyFinancialRecordResponseDto>> UpdateRecord(int id, DailyFinancialRecordUpdateDto record);
    Task<Result<DailyFinancialRecordResponseDto>> DeleteRecord(int id);
    Task<Result<DailyFinancialSummaryDto>> GetSummary(DateTimeOffset from, DateTimeOffset to);
}
