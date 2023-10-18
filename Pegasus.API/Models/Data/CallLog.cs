namespace Pegasus.API.Models.Data;

public class CallLog
{
    public int Id { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContactName { get; set; }
    public string? Direction { get; set; }
    public DateTime CallDate { get; set; }
    public int Duration { get; set; }
    public string? Notes { get; set; }
    public DateTime LogDate { get; set; } = DateTime.Now;
}