using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Core.Bcm.BcmModel;
using Sdl.Core.Bcm.BcmModel.Annotations;
using Sdl.Core.Bcm.BcmModel.Common;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public class PlainTextVisitor: BcmVisitor
    {
        public ConfirmationLevel ConfirmationLevel { get; set; }
        private readonly StringBuilder _textBuilder = new StringBuilder();

        public string Result => _textBuilder.ToString();
        public static string CollectText(MarkupData markupData)
        {
            var collector = new PlainTextVisitor();
            markupData.AcceptVisitor(collector);
            return collector.Result;
        }

        public override void VisitStructure(StructureTag structureTag)
        {

        }

        public override void VisitTagPair(TagPair tagPair)
        {
            VisitChildren(tagPair);
        }

        public override void VisitPlaceholderTag(PlaceholderTag tag)
        {
        }

        public override void VisitText(TextMarkup text)
        {
            _textBuilder.Append(text.Text);
        }

        public override void VisitSegment(Segment segment)
        {
            VisitChildren(segment);
        }
        private void VisitChildren(MarkupDataContainer container)
        {
            container.ForEach(markup => markup.AcceptVisitor(this));
        }

        public override void VisitCommentContainer(CommentContainer commentContainer)
        {
            VisitChildren(commentContainer);
        }

        public override void VisitLockedContentContainer(LockedContentContainer lockedContentContainer)
        {
            VisitChildren(lockedContentContainer);
        }

        public override void VisitRevisionContainer(RevisionContainer revisionContainer)
        {
            if (revisionContainer.RevisionType != RevisionType.Deleted)
            {
                VisitChildren(revisionContainer);
            }
        }

        public override void VisitFeedbackContainer(FeedbackContainer feedbackContainer)
        {
            if (feedbackContainer.FeedbackType != FeedbackType.Deleted)
            {
                VisitChildren(feedbackContainer);
            }
        }

        public override void VisitParagraph(Paragraph paragraph)
        {
        }

        public override void VisitTerminologyContainer(TerminologyAnnotationContainer terminologyAnnotation)
        {
            VisitChildren(terminologyAnnotation);
        }
    }
}
