using Partify.Application.Common;
using Partify.Application.DTOs.Invoices;

namespace Partify.Application.ServiceContracts;

public interface IInvoiceService
{
    Task<Result<IEnumerable<InvoiceResponseDto>>> GetInvoices();
    Task<Result<InvoiceResponseDto>> GetInvoiceById(int id);
    Task<Result<InvoiceResponseDto>> CreateInvoice(InvoiceAddDto invoice);
    Task<Result<InvoiceResponseDto>> UpdateInvoice(int id, InvoiceUpdateDto invoice);
    Task<Result<InvoiceResponseDto>> DeleteInvoice(int id);
}
