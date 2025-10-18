using Microsoft.AspNetCore.Mvc;
using Partify.API.Controllers.Base;
using Partify.Application.DTOs.DailyFinancialRecords;
using Partify.Application.ServiceContracts;

namespace Partify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : BaseController
    {
        private readonly IDailyFinancialRecordService _dailyFinancialRecordService;
        public FinancialController(IDailyFinancialRecordService dailyFinancialRecordService)
        {
            _dailyFinancialRecordService = dailyFinancialRecordService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyFinancialRecordResponseDto>>> GetRecords() => HandleResultResponse(await _dailyFinancialRecordService.GetRecords());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DailyFinancialRecordResponseDto>> GetRecordById(int id) => HandleResultResponse(await _dailyFinancialRecordService.GetRecordById(id));

        [HttpPost]
        public async Task<ActionResult<DailyFinancialRecordResponseDto>> CreateRecord([FromBody] DailyFinancialRecordAddDto record) => HandleResultResponse(await _dailyFinancialRecordService.CreateRecord(record));

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DailyFinancialRecordResponseDto>> UpdateRecord(int id, [FromBody] DailyFinancialRecordUpdateDto record) => HandleResultResponse(await _dailyFinancialRecordService.UpdateRecord(id, record));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DailyFinancialRecordResponseDto>> DeleteRecord(int id) => HandleResultResponse(await _dailyFinancialRecordService.DeleteRecord(id));

        [HttpGet("summary")]
        public async Task<ActionResult<DailyFinancialSummaryDto>> GetSummary([FromQuery] DateTimeOffset from, [FromQuery] DateTimeOffset to)
            => HandleResultResponse(await _dailyFinancialRecordService.GetSummary(from, to));
    }
}
