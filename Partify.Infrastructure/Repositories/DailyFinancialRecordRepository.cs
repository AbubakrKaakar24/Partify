using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts;
using Partify.Infrastructure.AppDbContext;
using Partify.Infrastructure.Repositories.Base;

namespace Partify.Infrastructure.Repositories;

public class DailyFinancialRecordRepository : GenericRepository<DailyFinancialRecord>, IDailyFinancialRecordRepository
{
    public DailyFinancialRecordRepository(PortifyDbContext context) : base(context)
    {
    }
}
