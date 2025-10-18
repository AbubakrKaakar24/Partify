namespace Partify.Domain.Entities;

using Partify.Domain.Entities.Base;

public class Receipt : AuditableEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }

    public Customer? Customer { get; set; }
}
