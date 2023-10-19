namespace Pegasus.API;

public static class DateTimeExtensions
{
    private static readonly DateTimeOffset UnixEpoch = new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static DateTime ToDateTime(this long timestamp)
    {
        DateTimeOffset dateTimeOffset = UnixEpoch.AddMilliseconds(timestamp);
        return dateTimeOffset.DateTime.AddHours(2);
    }
}