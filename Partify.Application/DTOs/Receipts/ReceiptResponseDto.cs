namespace Partify.Application.DTOs.Receipts;

public class ReceiptResponseDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
}
