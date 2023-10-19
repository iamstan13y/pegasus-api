using Pegasus.API.Models.Data;
using Pegasus.API.Models.Local;

namespace Pegasus.API.Models.Repository;

public interface ICallLogRepository
{
    Task<Result<CallLog>> AddAsync(CallLog callLog);
    Task<Result<IEnumerable<CallLog>>> GetAllAsync();
    Task<Result<CallLog>> GetByIdAsync(int id);
}