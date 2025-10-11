using Partify.Domain.RespositoryContracts;
using Partify.Domain.RespositoryContracts.Base;
using Partify.Infrastructure.AppDbContext;


namespace Partify.Infrastructure.Repositories.Base
{

    public class UnitOfWork: IUnitOfWork
    {
        private readonly PortifyDbContext _dbContext;

        public UnitOfWork(PortifyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICustomerRepository? _customerRepository;
        public ICustomerRepository CustomerRepository=> _customerRepository ??= new CustomerRepository(_dbContext);
        public async Task<int> SaveChangesAsync( CancellationToken token )
        {
            return await _dbContext.SaveChangesAsync(token);
        }
    }
}
