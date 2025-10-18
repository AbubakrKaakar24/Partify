using Microsoft.AspNetCore.Mvc;
using Partify.API.Controllers.Base;
using Partify.Application.DTOs.Purchases;
using Partify.Application.ServiceContracts;

namespace Partify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : BaseController
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseResponseDto>>> GetPurchases() => HandleResultResponse(await _purchaseService.GetPurchases());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchaseResponseDto>> GetPurchaseById(int id) => HandleResultResponse(await _purchaseService.GetPurchaseById(id));

        [HttpGet("supplier/{supplierId:int}")]
        public async Task<ActionResult<IEnumerable<PurchaseResponseDto>>> GetPurchasesBySupplier(int supplierId) => HandleResultResponse(await _purchaseService.GetPurchasesBySupplier(supplierId));

        [HttpPost]
        public async Task<ActionResult<PurchaseResponseDto>> CreatePurchase([FromBody] PurchaseAddDto purchase) => HandleResultResponse(await _purchaseService.CreatePurchase(purchase));

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PurchaseResponseDto>> UpdatePurchase(int id, [FromBody] PurchaseUpdateDto purchase) => HandleResultResponse(await _purchaseService.UpdatePurchase(id, purchase));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PurchaseResponseDto>> DeletePurchase(int id) => HandleResultResponse(await _purchaseService.DeletePurchase(id));
    }
}
