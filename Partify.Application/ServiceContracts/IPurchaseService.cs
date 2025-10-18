using Partify.Application.Common;
using Partify.Application.DTOs.Purchases;

namespace Partify.Application.ServiceContracts;

public interface IPurchaseService
{
    Task<Result<IEnumerable<PurchaseResponseDto>>> GetPurchases();
    Task<Result<PurchaseResponseDto>> GetPurchaseById(int id);
    Task<Result<PurchaseResponseDto>> CreatePurchase(PurchaseAddDto purchase);
    Task<Result<PurchaseResponseDto>> UpdatePurchase(int id, PurchaseUpdateDto purchase);
    Task<Result<PurchaseResponseDto>> DeletePurchase(int id);
    Task<Result<IEnumerable<PurchaseResponseDto>>> GetPurchasesBySupplier(int supplierId);
}
