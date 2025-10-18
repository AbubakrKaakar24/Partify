namespace Partify.Application.DTOs.DailyFinancialRecords;

public class DailyFinancialSummaryDto
{
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal TotalProfit { get; set; }
    public int RecordCount { get; set; }
}
