namespace Presentation.Detection.Fetching.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Detection.Fetching.Models;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TTimestampFilter : InputObjectGraphType<MTimestampFilter>
    {
        public TTimestampFilter()
        {
            Name = "TimestampFilter";
            Description = "This will be used for filtering the detections by timestamp";

            Field(timestamp => timestamp.LesserEqualThan, true).Description("Detections will have the timestamp lesser than this value");
            Field(timestamp => timestamp.GreaterEqualThan, true).Description("Detections will have the timestamp greater than this value");
        }
    }
}
