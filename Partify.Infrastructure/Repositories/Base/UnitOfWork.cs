using Partify.Domain.RespositoryContracts;
using Partify.Domain.RespositoryContracts.Base;
using Partify.Infrastructure.AppDbContext;
using Partify.Infrastructure.Repositories;

namespace Partify.Infrastructure.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly PortifyDbContext _dbContext;

    public UnitOfWork(PortifyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private ICustomerRepository? _customerRepository;
    public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_dbContext);

    private IInvoiceRepository? _invoiceRepository;
    public IInvoiceRepository InvoiceRepository => _invoiceRepository ??= new InvoiceRepository(_dbContext);

    private IReceiptRepository? _receiptRepository;
    public IReceiptRepository ReceiptRepository => _receiptRepository ??= new ReceiptRepository(_dbContext);

    private IDailyFinancialRecordRepository? _dailyFinancialRecordRepository;
    public IDailyFinancialRecordRepository DailyFinancialRecordRepository => _dailyFinancialRecordRepository ??= new DailyFinancialRecordRepository(_dbContext);

    private ISupplierRepository? _supplierRepository;
    public ISupplierRepository SupplierRepository => _supplierRepository ??= new SupplierRepository(_dbContext);

    private IPurchaseRepository? _purchaseRepository;
    public IPurchaseRepository PurchaseRepository => _purchaseRepository ??= new PurchaseRepository(_dbContext);

    public async Task<int> SaveChangesAsync(CancellationToken token)
    {
        return await _dbContext.SaveChangesAsync(token);
    }
}
