namespace Partify.Application.DTOs.Invoices;

public class InvoiceAddDto
{
    public int CustomerId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; }
}
