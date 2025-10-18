namespace Partify.Application.DTOs.DailyFinancialRecords;

public class DailyFinancialRecordUpdateDto
{
    public decimal? Revenue { get; set; }
    public decimal? Expenses { get; set; }
    public decimal? Profit { get; set; }
    public DateTimeOffset? Date { get; set; }
}
