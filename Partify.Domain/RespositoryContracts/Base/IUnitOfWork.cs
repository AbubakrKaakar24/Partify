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
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
