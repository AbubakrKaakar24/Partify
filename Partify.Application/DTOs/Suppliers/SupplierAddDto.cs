namespace Partify.Application.DTOs.Suppliers;

public class SupplierAddDto
{
    public string Name { get; set; } = string.Empty;
    public string? ContactEmail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
