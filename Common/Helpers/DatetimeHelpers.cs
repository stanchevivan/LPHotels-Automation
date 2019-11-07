using System;
using Fourth.Orchestration.Model;

namespace Common.Helpers
{
    public static class DatetimeHelpers
    {
        public static DateTime ConvertUnixTimeStampToDatetime(long timeStamp)
        {
            return UnixDateTime.ToDateTimeUtc(timeStamp);
        }
    }
}
