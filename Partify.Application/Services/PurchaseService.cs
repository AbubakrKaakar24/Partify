using AutoMapper;
using Partify.Application.Common;
using Partify.Application.DTOs.Purchases;
using Partify.Application.ServiceContracts;
using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts.Base;

namespace Partify.Application.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PurchaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PurchaseResponseDto>> CreatePurchase(PurchaseAddDto purchase)
    {
        var entity = _mapper.Map<Purchase>(purchase);
        await _unitOfWork.PurchaseRepository.Add(entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<PurchaseResponseDto>.SuccessResult(_mapper.Map<PurchaseResponseDto>(entity));
    }

    public async Task<Result<PurchaseResponseDto>> DeletePurchase(int id)
    {
        var entity = await _unitOfWork.PurchaseRepository.GetById(id);
        await _unitOfWork.PurchaseRepository.Delete(entity!);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<PurchaseResponseDto>.SuccessResult(_mapper.Map<PurchaseResponseDto>(entity));
    }

    public async Task<Result<PurchaseResponseDto>> GetPurchaseById(int id)
    {
        var entity = await _unitOfWork.PurchaseRepository.GetById(id);
        return Result<PurchaseResponseDto>.SuccessResult(_mapper.Map<PurchaseResponseDto>(entity));
    }

    public async Task<Result<IEnumerable<PurchaseResponseDto>>> GetPurchases()
    {
        var entities = await _unitOfWork.PurchaseRepository.GetAll();
        var mapped = _mapper.Map<IEnumerable<PurchaseResponseDto>>(entities);
        return Result<IEnumerable<PurchaseResponseDto>>.SuccessResult(mapped);
    }

    public async Task<Result<IEnumerable<PurchaseResponseDto>>> GetPurchasesBySupplier(int supplierId)
    {
        var entities = await _unitOfWork.PurchaseRepository.GetAll(p => p.SupplierId == supplierId);
        var mapped = _mapper.Map<IEnumerable<PurchaseResponseDto>>(entities);
        return Result<IEnumerable<PurchaseResponseDto>>.SuccessResult(mapped);
    }

    public async Task<Result<PurchaseResponseDto>> UpdatePurchase(int id, PurchaseUpdateDto purchase)
    {
        var entity = await _unitOfWork.PurchaseRepository.GetFirstOrDefault(p => p.Id == id);
        _mapper.Map(purchase, entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<PurchaseResponseDto>.SuccessResult(_mapper.Map<PurchaseResponseDto>(entity));
    }
}
