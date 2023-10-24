namespace Pegasus.API.Models.Local;

public class UnformattedCallLogRequest
{
    public string? Number { get; set; }
    public string? Type { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
    public int Duration { get; set; }
    public string? Contact { get; set; }
}