using Microsoft.AspNetCore.Mvc;
using Partify.API.Controllers.Base;
using Partify.Application.DTOs.Suppliers;
using Partify.Application.ServiceContracts;

namespace Partify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : BaseController
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierResponseDto>>> GetSuppliers() => HandleResultResponse(await _supplierService.GetSuppliers());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierResponseDto>> GetSupplierById(int id) => HandleResultResponse(await _supplierService.GetSupplierById(id));

        [HttpPost]
        public async Task<ActionResult<SupplierResponseDto>> CreateSupplier([FromBody] SupplierAddDto supplier) => HandleResultResponse(await _supplierService.CreateSupplier(supplier));

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SupplierResponseDto>> UpdateSupplier(int id, [FromBody] SupplierUpdateDto supplier) => HandleResultResponse(await _supplierService.UpdateSupplier(id, supplier));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SupplierResponseDto>> DeleteSupplier(int id) => HandleResultResponse(await _supplierService.DeleteSupplier(id));

        [HttpGet("{id:int}/outstanding")]
        public async Task<ActionResult<SupplierOutstandingDto>> GetOutstanding(int id) => HandleResultResponse(await _supplierService.GetOutstanding(id));

        [HttpGet("outstanding")]
        public async Task<ActionResult<IEnumerable<SupplierOutstandingDto>>> GetOutstandingAll() => HandleResultResponse(await _supplierService.GetOutstandingAll());
    }
}
