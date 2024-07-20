using Pegasus.API.Models.Data;
using Pegasus.API.Models.Local;

namespace Pegasus.API.Models.Repository;

public interface ICallLogRepository
{
    Task<Result<CallLog>> AddAsync(CallLogRequest callLogRequest);
    Task<Result<string>> AddBulkAsync(List<CallLog> callLogs);
    Task<Result<IEnumerable<CallLog>>> GetAllAsync();
    Task<Result<CallLog>> GetByIdAsync(int id);
}