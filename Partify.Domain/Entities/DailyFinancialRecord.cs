using Partify.Domain.Entities.Base;

namespace Partify.Domain.Entities;

public class DailyFinancialRecord : AuditableEntity
{
    public int Id { get; set; }
    public decimal Revenue { get; set; }
    public decimal Expenses { get; set; }
    public decimal Profit { get; set; } // Entered by user (can differ from Revenue-Expenses if needed)
    public DateTimeOffset Date { get; set; }
}
