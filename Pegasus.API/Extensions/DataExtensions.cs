using Pegasus.API.Models.Enums;
using Pegasus.API.Models.Local;
using System.Globalization;

namespace Pegasus.API.Extensions;

public static class DataExtensions
{
    public static List<CallLogRequest> SanitizeData(this List<UnformattedCallLogRequest> data)
    {
        var sanitizedData = new List<CallLogRequest>();

        foreach (var callLog in data)
        {
            sanitizedData.Add(new CallLogRequest
            {
                Contact = callLog.Contact?.Sanitize(),
                Direction = (int)(CallType)Enum.Parse(typeof(CallType), callLog.Type),
                Date = DateTime.ParseExact($"{callLog.Date} {callLog.Time}", "dd-MMM-yy HH:mm", CultureInfo.InvariantCulture).ToUnixTimeStamp(),
                Duration = callLog.Duration,
                Number = callLog.Number?.SanitizePhoneNumber()
            });
        }

        return sanitizedData;
    }
}