using Pegasus.API.Models.Data;
using Pegasus.API.Models.Local;
using System.Globalization;

namespace Pegasus.API.Extensions;

public static class DataExtensions
{
    public static List<CallLog> SanitizeData(this List<UnformattedCallLogRequest> data)
    {
        var sanizitedData = new List<CallLog>();

        foreach (var callLog in data)
        {
            sanizitedData.Add(new CallLog
            {
                //ContactName = callLog.Contact?.Sanitize(),
                //Type = callLog.Type,
                CallDate = DateTime.ParseExact($"{callLog.Date} {callLog.Time}", "dd-MMM-yy HH:mm", CultureInfo.InvariantCulture),
                Duration = callLog.Duration,
                //PhoneNumber = callLog.Number?.SanitizePhoneNumber()
            });
        }

        return sanizitedData;
    }
}