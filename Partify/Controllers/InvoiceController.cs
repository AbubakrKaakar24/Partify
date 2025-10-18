using Microsoft.AspNetCore.Mvc;
using Partify.API.Controllers.Base;
using Partify.Application.DTOs.Invoices;
using Partify.Application.ServiceContracts;

namespace Partify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceResponseDto>>> GetInvoices() => HandleResultResponse(await _invoiceService.GetInvoices());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvoiceResponseDto>> GetInvoiceById(int id) => HandleResultResponse(await _invoiceService.GetInvoiceById(id));

        [HttpPost]
        public async Task<ActionResult<InvoiceResponseDto>> CreateInvoice([FromBody] InvoiceAddDto invoice) => HandleResultResponse(await _invoiceService.CreateInvoice(invoice));

        [HttpPut("{id:int}")]
        public async Task<ActionResult<InvoiceResponseDto>> UpdateInvoice(int id, [FromBody] InvoiceUpdateDto invoice) => HandleResultResponse(await _invoiceService.UpdateInvoice(id, invoice));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<InvoiceResponseDto>> DeleteInvoice(int id) => HandleResultResponse(await _invoiceService.DeleteInvoice(id));
    }
}
