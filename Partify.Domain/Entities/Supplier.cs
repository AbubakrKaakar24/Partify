using Partify.Domain.Entities.Base;
using System.Collections.Generic;

namespace Partify.Domain.Entities;

public class Supplier : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ContactEmail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
