using Partify.Application.Common;
using Partify.Application.DTOs.Receipts;

namespace Partify.Application.ServiceContracts;

public interface IReceiptService
{
    Task<Result<IEnumerable<ReceiptResponseDto>>> GetReceipts();
    Task<Result<ReceiptResponseDto>> GetReceiptById(int id);
    Task<Result<ReceiptResponseDto>> CreateReceipt(ReceiptAddDto receipt);
    Task<Result<ReceiptResponseDto>> UpdateReceipt(int id, ReceiptUpdateDto receipt);
    Task<Result<ReceiptResponseDto>> DeleteReceipt(int id);
}
