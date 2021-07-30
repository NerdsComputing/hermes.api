namespace Presentation.Detection.Fetching.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Detection.Fetching.Models;
    using global::GraphQL.Types;
    using Presentation.Pagination.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPDetection : InputObjectGraphType<PDetection>
    {
        public TPDetection()
        {
            Name = "DetectionParameter";
            Description = "This will be used for filtering the detections";

            Field(detection => detection.Id, true).Description("This is the Id based on which the filtering is done (it can be null)");
            Field(detection => detection.ScoreFilter, true, typeof(TScoreFilter)).Description("This is the Score based on which the filtering is done (it can be null)");
            Field(detection => detection.Class, true).Description("This is the Class based on which the filtering is done (it can be null)");
            Field(detection => detection.Timestamp, true, typeof(TTimestamp))
                .Description("This is the timestamp based on which the filtering is done (it can be null)");
            Field(detection => detection.Pagination, false, typeof(TPPagination)).Description("This is the Pagination based on which the pagination info is done");
            Field(detection => detection.CameraId, true).Description("This is the CameraId based on which the filtering is done (it can be null)");
        }
    }
}
