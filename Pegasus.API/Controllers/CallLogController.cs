using Microsoft.AspNetCore.Mvc;
using Pegasus.API.Extensions;
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
            var result = await _repository.AddAsync(request);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("import")]
        public async Task<IActionResult> PostBulk(List<UnformattedCallLogRequest> request)
        {
            var result = await _repository.AddBulkAsync(request);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}