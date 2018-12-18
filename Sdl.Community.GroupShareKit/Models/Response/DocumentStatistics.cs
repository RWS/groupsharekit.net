using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class DocumentStatistics
    {
        public int DocumentId { get; set; }

        public CountData Total { get; set; }

        public CountData DocumentRepetitions { get; set; } = new CountData();

        public CountData CrossDocumentRepetitions { get; set; } = new CountData();

        public List<DetailedDocumentStatistics> DetailedDocumentStatistics { get; set; } = new List<DetailedDocumentStatistics>();
    }
}
