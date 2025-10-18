namespace Partify.Application.DTOs.Invoices;

public class InvoiceUpdateDto
{
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
    public decimal? TotalCost { get; set; }
}
