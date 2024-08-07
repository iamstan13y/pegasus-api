﻿namespace Pegasus.API.Extensions;

public static class DateTimeExtensions
{
    private static readonly DateTimeOffset UnixEpoch = new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static DateTime ToDateTime(this long timestamp)
    {
        DateTimeOffset dateTimeOffset = UnixEpoch.AddMilliseconds(timestamp);
        return dateTimeOffset.DateTime.AddHours(2);
    }

    public static long ToUnixTimeStamp(this DateTime dateTime)
    {
        DateTimeOffset dateTimeOffset = new(dateTime);
        return (long)(dateTimeOffset - UnixEpoch).TotalMilliseconds;
    }
}