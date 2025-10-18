using Partify.Domain.Entities.Base;
using System;

namespace Partify.Domain.Entities;

public class Purchase : AuditableEntity
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; } // Total cost agreed with supplier
    public decimal AmountPaid { get; set; } // How much has been paid so far
    public DateTimeOffset PurchaseDate { get; set; }

    public decimal AmountOwed => TotalCost - AmountPaid;

    public Supplier? Supplier { get; set; }
}
