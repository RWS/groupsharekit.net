using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Sdl.Core.Bcm.BcmModel;
using Sdl.TmService.Sdk.Model.Search;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public static class FilterResults
    {
        public static List<FilterResponse> GetFilterResultForDocument(Document document, RestScoringResult scoringResult)
        {
            var searchResult = new List<FilterResponse>();

            if (document == null)
            {
                return searchResult;
            }

            foreach (var file in document.Files)
            {
                foreach (var paragraphUnit in file.ParagraphUnits)
                {
                    if (paragraphUnit.IsStructure)
                    {
                        continue;
                    }

                    foreach (var pair in paragraphUnit.SegmentPairs)
                    {
                        var sourceText = FilterExpression.ConvertSegmentPair(pair.Source);
                        var targetText = FilterExpression.ConvertSegmentPair(pair.Target);
                        var matchScore = scoringResult != null ? scoringResult.Match.ToString() : string.Empty;

                        searchResult.Add(new FilterResponse { Source = sourceText, Target = targetText, MatchScore = matchScore });
                    }
                }
            }

            return searchResult;
        }
    }
}
