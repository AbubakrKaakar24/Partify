using Partify.Application.Common;
using Partify.Application.DTOs.Suppliers;

namespace Partify.Application.ServiceContracts;

public interface ISupplierService
{
    Task<Result<IEnumerable<SupplierResponseDto>>> GetSuppliers();
    Task<Result<SupplierResponseDto>> GetSupplierById(int id);
    Task<Result<SupplierResponseDto>> CreateSupplier(SupplierAddDto supplier);
    Task<Result<SupplierResponseDto>> UpdateSupplier(int id, SupplierUpdateDto supplier);
    Task<Result<SupplierResponseDto>> DeleteSupplier(int id);
    Task<Result<SupplierOutstandingDto>> GetOutstanding(int supplierId);
    Task<Result<IEnumerable<SupplierOutstandingDto>>> GetOutstandingAll();
}
