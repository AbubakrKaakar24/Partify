using AutoMapper;
using Partify.Application.Common;
using Partify.Application.DTOs.Receipts;
using Partify.Application.ServiceContracts;
using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts.Base;

namespace Partify.Application.Services;

public class ReceiptService : IReceiptService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ReceiptService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ReceiptResponseDto>> CreateReceipt(ReceiptAddDto receipt)
    {
        var entity = _mapper.Map<Receipt>(receipt);
        await _unitOfWork.ReceiptRepository.Add(entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<ReceiptResponseDto>.SuccessResult(_mapper.Map<ReceiptResponseDto>(entity));
    }

    public async Task<Result<ReceiptResponseDto>> DeleteReceipt(int id)
    {
        var entity = await _unitOfWork.ReceiptRepository.GetById(id);
        await _unitOfWork.ReceiptRepository.Delete(entity!);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<ReceiptResponseDto>.SuccessResult(_mapper.Map<ReceiptResponseDto>(entity));
    }

    public async Task<Result<ReceiptResponseDto>> GetReceiptById(int id)
    {
        var entity = await _unitOfWork.ReceiptRepository.GetById(id);
        return Result<ReceiptResponseDto>.SuccessResult(_mapper.Map<ReceiptResponseDto>(entity));
    }

    public async Task<Result<IEnumerable<ReceiptResponseDto>>> GetReceipts()
    {
        var entities = await _unitOfWork.ReceiptRepository.GetAll();
        var mapped = _mapper.Map<IEnumerable<ReceiptResponseDto>>(entities);
        return Result<IEnumerable<ReceiptResponseDto>>.SuccessResult(mapped);
    }

    public async Task<Result<ReceiptResponseDto>> UpdateReceipt(int id, ReceiptUpdateDto receipt)
    {
        var entity = await _unitOfWork.ReceiptRepository.GetFirstOrDefault(r => r.Id == id);
        _mapper.Map(receipt, entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<ReceiptResponseDto>.SuccessResult(_mapper.Map<ReceiptResponseDto>(entity));
    }
}
