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

            Field(detection => detection.Id, true).Description("This is the ID");
            Field(detection => detection.Score, true).Description("This is the Score");
            Field(detection => detection.Timestamp, true).Description("This is the Timestamp");
            Field(detection => detection.Class, true).Description("This is the Class");
            Field(detection => detection.Pagination, false, typeof(TPPagination)).Description("This is the pagination");
            Field(detection => detection.CameraId, true).Description("The camera id that took the detection");
        }
    }
}
