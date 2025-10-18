using System;

namespace Partify.Application.DTOs.Purchases;

public class PurchaseUpdateDto
{
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? AmountPaid { get; set; }
    public DateTimeOffset? PurchaseDate { get; set; }
}
