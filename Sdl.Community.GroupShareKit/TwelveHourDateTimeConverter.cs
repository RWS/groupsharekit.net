using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace Sdl.Community.GroupShareKit
{
    public class TwelveHourDateTimeConverter : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(DateTime?))
            {
                throw new Exception($"The {nameof(TwelveHourDateTimeConverter)} class expects to convert to DateTime, not {objectType.Name}.");
            }

            var incomingVal = reader.Value.ToString();

            if (new System.Text.RegularExpressions.Regex(@"(\d{1,2}\/\d{1,2}\/\d{4} \d{1,2}:\d{1,2} (AM)|(PM))").IsMatch(incomingVal))
            {
                return DateTime.ParseExact(incomingVal,
                                           "dd/M/yyyy h:mm tt",
                                           CultureInfo.InvariantCulture);
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}