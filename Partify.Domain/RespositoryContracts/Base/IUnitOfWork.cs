using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partify.Domain.RespositoryContracts.Base
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IReceiptRepository ReceiptRepository { get; }
        IDailyFinancialRecordRepository DailyFinancialRecordRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
