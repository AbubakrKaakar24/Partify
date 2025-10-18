using AutoMapper;
using Partify.Application.Common;
using Partify.Application.DTOs.Customers;
using Partify.Application.Mapping;
using Partify.Application.ServiceContracts;
using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts.Base;
using System;

namespace Partify.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<CustomerResponseDto>> CreateCustomer(CustomerAddDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            await _unitOfWork.CustomerRepository.Add(customerEntity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<CustomerResponseDto>.SuccessResult(_mapper.Map<CustomerResponseDto>(customerEntity));
        }

        public async Task<Result<CustomerResponseDto>> DeleteCustomer(int id)
        {
            var customerEntity = await _unitOfWork.CustomerRepository.GetById(id);
            await _unitOfWork.CustomerRepository.Delete(customerEntity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<CustomerResponseDto>.SuccessResult(_mapper.Map<CustomerResponseDto>(customerEntity));
        }

        public async Task<Result<CustomerResponseDto>> GetCustomerById(int id)
        {
            var customerEntity = await _unitOfWork.CustomerRepository.GetById(id);
            return  Result<CustomerResponseDto>.SuccessResult(_mapper.Map<CustomerResponseDto>(customerEntity));
        }

        public async Task<Result<IEnumerable<CustomerResponseDto>>> GetCustomers()
        {
            var customerEntities = await _unitOfWork.CustomerRepository.GetAll();
            var mappedCustomers = _mapper.Map<IEnumerable<CustomerResponseDto>>(customerEntities);
            return Result<IEnumerable<CustomerResponseDto>>.SuccessResult(mappedCustomers);
        }

        public async Task<Result<CustomerResponseDto>> UpdateCustomer(int id, CustomerUpdateDto customer)
        {
            var customerEntity = await _unitOfWork.CustomerRepository.GetFirstOrDefault(c=> c.Id==id);
            _mapper.Map(customer, customerEntity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<CustomerResponseDto>.SuccessResult(_mapper.Map<CustomerResponseDto>(customerEntity));
        }

        public async Task<Result<decimal>> GetOutstanding(int customerId)
        {
            var customerEntity = await _unitOfWork.CustomerRepository.GetById(customerId);
            if (customerEntity == null)
            {
                return Result<decimal>.NotFoundResult(customerId);
            }

            var invoices = await _unitOfWork.InvoiceRepository.GetAll(i => i.CustomerId == customerId);
            var receipts = await _unitOfWork.ReceiptRepository.GetAll(r => r.CustomerId == customerId);

            var totalInvoice = invoices.Sum(i => i.TotalCost);
            var totalReceipt = receipts.Sum(r => r.Amount);
            var outstanding = totalInvoice - totalReceipt;
            return Result<decimal>.SuccessResult(outstanding);
        }
    }
}
