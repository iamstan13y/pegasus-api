using Microsoft.AspNetCore.Mvc;
using Pegasus.API.Extensions;
using Pegasus.API.Models.Data;
using Pegasus.API.Models.Enums;
using Pegasus.API.Models.Local;
using Pegasus.API.Models.Repository;

namespace Pegasus.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CallLogController : ControllerBase
    {
        private readonly ICallLogRepository _repository;

        public CallLogController(ICallLogRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CallLogRequest request)
        {
            var result = await _repository.AddAsync(new CallLog
            {
                ContactName = request.Contact?.Sanitize(),
                CallDate = request.Date.ToDateTime(),
                Type = ((CallType)request.Direction).ToString(),
                Duration = request.Duration,
                Notes = request.Notes?.Sanitize(),
                PhoneNumber = request.Number?.SanitizePhoneNumber(),
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("/import")]
        public async Task<IActionResult> PostBulk(List<UnformattedCallLogRequest> request)
        {
            var result = await _repository.AddBulkAsync(request.SanitizeData());

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}