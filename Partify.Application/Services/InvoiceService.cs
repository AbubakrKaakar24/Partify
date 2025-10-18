using AutoMapper;
using Partify.Application.Common;
using Partify.Application.DTOs.Invoices;
using Partify.Application.ServiceContracts;
using Partify.Domain.Entities;
using Partify.Domain.RespositoryContracts.Base;

namespace Partify.Application.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<InvoiceResponseDto>> CreateInvoice(InvoiceAddDto invoice)
    {
        var entity = _mapper.Map<Invoice>(invoice);
        await _unitOfWork.InvoiceRepository.Add(entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<InvoiceResponseDto>.SuccessResult(_mapper.Map<InvoiceResponseDto>(entity));
    }

    public async Task<Result<InvoiceResponseDto>> DeleteInvoice(int id)
    {
        var entity = await _unitOfWork.InvoiceRepository.GetById(id);
        await _unitOfWork.InvoiceRepository.Delete(entity!);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<InvoiceResponseDto>.SuccessResult(_mapper.Map<InvoiceResponseDto>(entity));
    }

    public async Task<Result<InvoiceResponseDto>> GetInvoiceById(int id)
    {
        var entity = await _unitOfWork.InvoiceRepository.GetById(id);
        return Result<InvoiceResponseDto>.SuccessResult(_mapper.Map<InvoiceResponseDto>(entity));
    }

    public async Task<Result<IEnumerable<InvoiceResponseDto>>> GetInvoices()
    {
        var entities = await _unitOfWork.InvoiceRepository.GetAll();
        var mapped = _mapper.Map<IEnumerable<InvoiceResponseDto>>(entities);
        return Result<IEnumerable<InvoiceResponseDto>>.SuccessResult(mapped);
    }

    public async Task<Result<InvoiceResponseDto>> UpdateInvoice(int id, InvoiceUpdateDto invoice)
    {
        var entity = await _unitOfWork.InvoiceRepository.GetFirstOrDefault(i => i.Id == id);
        _mapper.Map(invoice, entity);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        return Result<InvoiceResponseDto>.SuccessResult(_mapper.Map<InvoiceResponseDto>(entity));
    }
}
