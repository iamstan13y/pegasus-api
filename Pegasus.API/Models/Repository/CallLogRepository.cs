using Pegasus.API.Models.Data;
using Pegasus.API.Models.Local;

namespace Pegasus.API.Models.Repository;

public class CallLogRepository : ICallLogRepository
{
    public Task<Result<CallLog>> AddAsync(CallLog callLog)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<CallLog>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<CallLog>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}