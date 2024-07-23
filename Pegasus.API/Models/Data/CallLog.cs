using Pegasus.API.Models.Enums;

namespace Pegasus.API.Models.Data;

public class CallLog
{
    public long Id { get; set; }
    public long? ContactId { get; set; }
    public CallType Type { get; set; }
    public DateTime CallDate { get; set; }
    public int Duration { get; set; }
    public string? Notes { get; set; }
    public DateTime LogDate { get; set; } = DateTime.UtcNow;
    public Contact? Contact { get; set; }
}