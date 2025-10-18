namespace Partify.Application.DTOs.Suppliers;

public class SupplierOutstandingDto
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public decimal TotalPurchases { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal TotalOwed { get; set; }
}
