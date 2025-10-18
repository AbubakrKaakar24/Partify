namespace Partify.Application.DTOs.DailyFinancialRecords;

public class DailyFinancialRecordResponseDto
{
    public int Id { get; set; }
    public decimal Revenue { get; set; }
    public decimal Expenses { get; set; }
    public decimal Profit { get; set; }
    public DateTimeOffset Date { get; set; }
}
