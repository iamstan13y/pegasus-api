using Pegasus.API.Models.Data;
using Pegasus.API.Models.Local;

namespace Pegasus.API.Models.Repository;

public class CallLogRepository : ICallLogRepository
{
    private readonly AppDbContext _context;

    public CallLogRepository(AppDbContext context) => _context = context;
    
    public async Task<Result<CallLog>> AddAsync(CallLog callLog)
    {
        try
        {
            await _context.CallLogs!.AddAsync(callLog);
            await _context.SaveChangesAsync();

            return new Result<CallLog>(callLog);
        }
        catch (Exception ex)
        {
            return new Result<CallLog>(false, $"An error occured:{ex.Message}");
        }
    }

    public async Task<Result<string>> AddBulkAsync(List<CallLog> callLogs)
    {
        try
        {
            await _context.CallLogs!.AddRangeAsync(callLogs);
            await _context.SaveChangesAsync();

            return new Result<string>("Successfully saved!");
        }
        catch (Exception ex)
        {
            return new Result<string>(false, $"An error occured:{ex.Message}");
        }
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