namespace Partify.Application.DTOs.Receipts;

public class ReceiptAddDto
{
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
}
