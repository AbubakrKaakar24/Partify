using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts;
using Partify.Infrastructure.AppDbContext;
using Partify.Infrastructure.Repositories.Base;

namespace Partify.Infrastructure.Repositories;

public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(PortifyDbContext context) : base(context)
    {
    }
}
