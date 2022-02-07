using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;


namespace Sdl.Community.GroupShareKit
{
    /// <summary>
    /// This class is necessary since the GroupShare (MultiTerm) RestAPI returns termbase creation date format depending on server settings (LTGS-9908).
    /// </summary>
    /// <remarks>
    /// - Unlike the name suggests, this converter can parse a DateTime string for any given format string, not only 12 hour formats. <b/>
    /// - To configure this converter set environment variable multiterm.dateFormatStr according to https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
    /// </remarks>
    public class TwelveHourDateTimeConverter : IsoDateTimeConverter
    {
        private const string _dateFormatStringEnvironmentVariable = "multiterm.dateFormatStr";
        private const string _defaultDateFormatString = "M/dd/yyyy h:mm tt";

        private static Lazy<string> _dateFormatString = new Lazy<string>(() => GetDateFormatStringSetting());


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(DateTime?))
            {
                throw new Exception($"The {nameof(TwelveHourDateTimeConverter)} class expects to convert to DateTime, not {objectType.Name}.");
            }

            var incomingVal = reader.Value.ToString();
            
            bool parsedSuccessfully = DateTime.TryParseExact(incomingVal,
                                           // fallback to _defaultDateFormatString is for backward compatibility
                                           _dateFormatString.Value ?? _defaultDateFormatString,
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.None,
                                           out DateTime parsedDatetime);

            return parsedSuccessfully ? parsedDatetime : base.ReadJson(reader, objectType, existingValue, serializer);
        }

        private static string GetDateFormatStringSetting()
        {
            var settingValue = Environment.GetEnvironmentVariable(_dateFormatStringEnvironmentVariable)
                ?? Environment.GetEnvironmentVariable(_dateFormatStringEnvironmentVariable, EnvironmentVariableTarget.User);
            return string.IsNullOrWhiteSpace(settingValue) ? null : settingValue;
        }
    }
}
