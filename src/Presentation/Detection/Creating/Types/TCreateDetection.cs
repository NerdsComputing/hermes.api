namespace Presentation.Detection.Creating.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Detection.Creating.Models;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public sealed class TCreateDetection : InputObjectGraphType<MCreateDetection>
    {
        public TCreateDetection()
        {
            Field(detection => detection.Score).Description("This is the Score");
            Field(detection => detection.Timestamp).Description("This is the Timestamp");
            Field(detection => detection.Class).Description("This is the Class");
            Field(detection => detection.CameraId).Description("This is the CameraId");
        }
    }
}
