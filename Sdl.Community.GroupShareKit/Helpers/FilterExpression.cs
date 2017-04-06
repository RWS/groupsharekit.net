using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Sdl.Core.Bcm.BcmModel;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public static class FilterExpression
    {
        public static string ConvertSegmentPair(Segment segment)
        {
            var visitor = new PlainTextVisitor();
            visitor.VisitSegment(segment);
            var result = visitor.Result;
            return result;

        }

        public static string CreateFilter(string searchText, bool isSorceText, bool caseSensitive, bool useWildCards)
        {
            //escape all special regex characters
            var regexPattern = Regex.Escape(searchText);
            if (useWildCards)
            {
                //interpret asterisks as wildcards (0 or more of any character == ".*" )
                regexPattern = regexPattern.Replace(@"\*", ".*");
            }
            if (!caseSensitive)
            {
                //make the entire expression case insensitive
                regexPattern = "(?i:" + regexPattern + ")";
            }


            var fieldValue = new ExpressionFieldValue
            {
                Name = "trg",
                Operator = "~",
                Value = regexPattern
            };

            var expression = fieldValue.ToString();

            return expression;
        }
    }
}
