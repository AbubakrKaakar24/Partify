using System;

namespace Partify.Application.DTOs.Purchases;

public class PurchaseAddDto
{
    public int SupplierId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTimeOffset PurchaseDate { get; set; }
}
