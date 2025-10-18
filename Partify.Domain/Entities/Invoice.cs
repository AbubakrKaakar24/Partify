using System;
using Partify.Domain.Entities.Base;

namespace Partify.Domain.Entities
{
    public class Invoice : AuditableEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }

        // Navigation
        public Customer? Customer { get; set; }
    }
}