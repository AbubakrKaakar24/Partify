using System;

namespace Partify.Application.DTOs.Purchases;

public class PurchaseResponseDto
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTimeOffset PurchaseDate { get; set; }
    public decimal AmountOwed { get; set; }
}
