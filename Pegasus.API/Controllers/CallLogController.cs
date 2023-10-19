using Microsoft.AspNetCore.Mvc;
using Pegasus.API.Models.Data;
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
                ContactName = request.Contact,
                CallDate = request.Date.ToDateTime(),
                Direction = request.Direction,
                Duration = request.Duration,
                Notes = request.Notes,
                PhoneNumber = request.Number
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}