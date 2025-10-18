using Partify.Application.Common;
using Partify.Application.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partify.Application.ServiceContracts
{
    public interface ICustomerService
    {
        public Task<Result<IEnumerable<CustomerResponseDto>>> GetCustomers();
        public Task<Result<CustomerResponseDto>> GetCustomerById(int id);
        public Task<Result<CustomerResponseDto>> CreateCustomer(CustomerAddDto customer);
        public Task<Result<CustomerResponseDto>> UpdateCustomer(int id, CustomerUpdateDto customer);
        public Task<Result<CustomerResponseDto>> DeleteCustomer(int id);
        public Task<Result<decimal>> GetOutstanding(int customerId);
    }
}
