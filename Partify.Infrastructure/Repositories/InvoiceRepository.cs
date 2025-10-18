using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts;
using Partify.Infrastructure.AppDbContext;
using Partify.Infrastructure.Repositories.Base;

namespace Partify.Infrastructure.Repositories;

public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(PortifyDbContext context) : base(context)
    {
    }
}
