namespace Pegasus.API.Models.Local;

public class CallLogRequest
{
    public string? Number { get; set; }
    public string? Contact { get; set; }
    public int Direction { get; set; }
    public long Date { get; set; }
    public int Duration { get; set; }
    public string? Notes { get; set; }
}