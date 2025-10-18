using AutoMapper;
using Partify.Application.Common;
using Partify.Application.DTOs.Suppliers;
using Partify.Application.ServiceContracts;
using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts.Base;

namespace Partify.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<SupplierResponseDto>> CreateSupplier(SupplierAddDto supplier)
    {
        var entity = _mapper.Map<Supplier>(supplier);
        await _unitOfWork.SupplierRepository.Add(entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<SupplierResponseDto>.SuccessResult(_mapper.Map<SupplierResponseDto>(entity));
    }

    public async Task<Result<SupplierResponseDto>> DeleteSupplier(int id)
    {
        var entity = await _unitOfWork.SupplierRepository.GetById(id);
        await _unitOfWork.SupplierRepository.Delete(entity!);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<SupplierResponseDto>.SuccessResult(_mapper.Map<SupplierResponseDto>(entity));
    }

    public async Task<Result<SupplierResponseDto>> GetSupplierById(int id)
    {
        var entity = await _unitOfWork.SupplierRepository.GetById(id);
        return Result<SupplierResponseDto>.SuccessResult(_mapper.Map<SupplierResponseDto>(entity));
    }

    public async Task<Result<IEnumerable<SupplierResponseDto>>> GetSuppliers()
    {
        var entities = await _unitOfWork.SupplierRepository.GetAll();
        var mapped = _mapper.Map<IEnumerable<SupplierResponseDto>>(entities);
        return Result<IEnumerable<SupplierResponseDto>>.SuccessResult(mapped);
    }

    public async Task<Result<SupplierResponseDto>> UpdateSupplier(int id, SupplierUpdateDto supplier)
    {
        var entity = await _unitOfWork.SupplierRepository.GetFirstOrDefault(s => s.Id == id);
        _mapper.Map(supplier, entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<SupplierResponseDto>.SuccessResult(_mapper.Map<SupplierResponseDto>(entity));
    }

    public async Task<Result<SupplierOutstandingDto>> GetOutstanding(int supplierId)
    {
        var supplier = await _unitOfWork.SupplierRepository.GetById(supplierId);
        if (supplier == null)
        {
            return Result<SupplierOutstandingDto>.NotFoundResult(supplierId);
        }
        var purchases = await _unitOfWork.PurchaseRepository.GetAll(p => p.SupplierId == supplierId);
        if (!purchases.Any())
        {
            return Result<SupplierOutstandingDto>.SuccessResult(new SupplierOutstandingDto
            {
                SupplierId = supplierId,
                SupplierName = supplier.Name,
                TotalPurchases = 0,
                TotalPaid = 0,
                TotalOwed = 0
            });
        }
        var dto = new SupplierOutstandingDto
        {
            SupplierId = supplierId,
            SupplierName = supplier.Name,
            TotalPurchases = purchases.Sum(p => p.TotalCost),
            TotalPaid = purchases.Sum(p => p.AmountPaid),
            TotalOwed = purchases.Sum(p => p.AmountOwed)
        };
        return Result<SupplierOutstandingDto>.SuccessResult(dto);
    }

    public async Task<Result<IEnumerable<SupplierOutstandingDto>>> GetOutstandingAll()
    {
        var suppliers = await _unitOfWork.SupplierRepository.GetAll();
        if (!suppliers.Any())
        {
            return Result<IEnumerable<SupplierOutstandingDto>>.EmptyResult("Supplier");
        }
        var purchases = await _unitOfWork.PurchaseRepository.GetAll();
        var list = suppliers.Select(s =>
        {
            var spPurchases = purchases.Where(p => p.SupplierId == s.Id).ToList();
            return new SupplierOutstandingDto
            {
                SupplierId = s.Id,
                SupplierName = s.Name,
                TotalPurchases = spPurchases.Sum(p => p.TotalCost),
                TotalPaid = spPurchases.Sum(p => p.AmountPaid),
                TotalOwed = spPurchases.Sum(p => p.AmountOwed)
            };
        }).ToList();
        return Result<IEnumerable<SupplierOutstandingDto>>.SuccessResult(list);
    }
}
