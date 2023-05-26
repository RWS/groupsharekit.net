using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Sdl.Core.Bcm.BcmModel;
using Sdl.TmService.Sdk.Model;

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

        public static string CreateFilter(LanguageDetailsRequest languageRequest, bool caseSensitive, bool useWildCards)
        {
            var sourceFieldExpression = string.Empty;
            var targetFieldExpression = string.Empty;
            var expression = string.Empty;

            //Create source expression
            if (!string.IsNullOrEmpty(languageRequest.SourceText))
            {
                var sourceExpr = EscapeCharacters(languageRequest.SourceText, caseSensitive, useWildCards);
                var sourceFieldValue = new ExpressionFieldValue
                {
                    Name = "src",
                    Operator = "~",
                    Value = sourceExpr
                };

                sourceFieldExpression = sourceFieldValue.ToString();
            }

            //Create target expression
            if (!string.IsNullOrEmpty(languageRequest.TargetText))
            {
                var targetExpr = EscapeCharacters(languageRequest.TargetText, caseSensitive, useWildCards);
                var targetFieldValue = new ExpressionFieldValue
                {
                    Name = "trg",
                    Operator = "~",
                    Value = targetExpr
                };

                targetFieldExpression = targetFieldValue.ToString();
            }

            // combine expressions if we have both source and target
            if (sourceFieldExpression != string.Empty && targetFieldExpression != string.Empty)
            {
                expression = sourceFieldExpression + "&" + targetFieldExpression;
            }
            else if (sourceFieldExpression != string.Empty)
            {
                expression = sourceFieldExpression;
            }
            else if (targetFieldExpression != string.Empty)
            {
                expression = targetFieldExpression;
            }

            return expression;
        }

        private static string EscapeCharacters(string searchText, bool caseSensitive, bool useWildCards)
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

            return regexPattern;
        }

        public static RestFilterExpression GetRestFilterExpression(string expression, LanguageDetailsRequest language)
        {
            var restFilterExpression = new RestFilterExpression();

            if (!string.IsNullOrEmpty(language.SourceText) && !string.IsNullOrEmpty(language.TargetText))
            {
                restFilterExpression.Expression = expression;
                restFilterExpression.Fields = new List<RequestField>
                {
                    new RequestField
                    {
                        Name = "src",
                        Type = "SingleString",
                        Values = null
                    },
                    new RequestField
                    {
                        Name = "trg",
                        Type = "SingleString",
                        Values = null
                    }
                };
            }
            else if (!string.IsNullOrEmpty(language.SourceText))
            {
                restFilterExpression.Expression = expression;
                restFilterExpression.Fields = new List<RequestField>
                {
                    new RequestField
                    {
                        Name = "src",
                        Type = "SingleString",
                        Values = null
                    }
                };
            }
            else if (!string.IsNullOrEmpty(language.TargetText))
            {
                //Create target expression
                restFilterExpression.Expression = expression;
                restFilterExpression.Fields = new List<RequestField>
                {
                    new RequestField
                    {
                        Name = "trg",
                        Type = "SingleString",
                        Values = null
                    }
                };
            }

            return restFilterExpression;
        }

        public static RestFilterExpression GetCustomRestFilterExpression(FieldFilterRequest filterRequest)
        {
            var customField = new List<RequestField>();

            foreach (var field in filterRequest.Fields)
            {
                var restFilter = new RequestField
                {
                    Name = field.Name,
                    Type = "SingleString",
                    Values = null
                };
                customField.Add(restFilter);
            }
            var restFilterExpression = new RestFilterExpression
            {
                Expression = filterRequest.Expression,
                Fields = customField
            };

            return restFilterExpression;
        }
    }
}
