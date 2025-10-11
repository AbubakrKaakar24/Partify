using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts;
using Partify.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partify.Infrastructure.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(AppDbContext.PortifyDbContext context):base(context)
        {
        }
    }
}
