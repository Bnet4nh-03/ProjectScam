using System.Globalization;

namespace ATV_Common_WebAPI.Common.Utilities;

public static class DateTimeConverterUtility
{
    public static string ConvertToDateTimeFormat(string input, string format)
    {
        DateTime parsedDate;

        // Try to parse the input date-time string
        if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        {
            // Return the date-time in the specified format
            return parsedDate.ToString(format);
        }
        else
        {
            // Return an error if the input format is incorrect
            return "Error";
        }
    }
}
