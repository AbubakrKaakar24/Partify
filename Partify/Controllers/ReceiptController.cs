using Microsoft.AspNetCore.Mvc;
using Partify.API.Controllers.Base;
using Partify.Application.DTOs.Receipts;
using Partify.Application.ServiceContracts;

namespace Partify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : BaseController
    {
        private readonly IReceiptService _receiptService;
        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptResponseDto>>> GetReceipts() => HandleResultResponse(await _receiptService.GetReceipts());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReceiptResponseDto>> GetReceiptById(int id) => HandleResultResponse(await _receiptService.GetReceiptById(id));

        [HttpPost]
        public async Task<ActionResult<ReceiptResponseDto>> CreateReceipt([FromBody] ReceiptAddDto receipt) => HandleResultResponse(await _receiptService.CreateReceipt(receipt));

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReceiptResponseDto>> UpdateReceipt(int id, [FromBody] ReceiptUpdateDto receipt) => HandleResultResponse(await _receiptService.UpdateReceipt(id, receipt));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ReceiptResponseDto>> DeleteReceipt(int id) => HandleResultResponse(await _receiptService.DeleteReceipt(id));
    }
}
