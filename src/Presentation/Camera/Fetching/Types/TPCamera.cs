namespace Presentation.Camera.Fetching.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Camera.Fetching.Models;
    using global::GraphQL.Types;
    using Presentation.Pagination.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPCamera : InputObjectGraphType<PCamera>
    {
        public TPCamera()
        {
            Name = "CameraParameter";
            Description = "Cameras will be filtered by this fields";

            Field(camera => camera.Ids, true)
                .Description("If no value will be given, then the cameras will not be filtered by id.");

            Field(camera => camera.Latitude, true, typeof(TPLatitude))
                .Description("If no value will be given, then the cameras will not be filtered by latitude.");

            Field(camera => camera.Longitude, true, typeof(TPLongitude))
                .Description("If no value will be given, then the cameras will not be filtered by longitude.");

            Field(camera => camera.Pagination, false, typeof(TPPagination))
                .Description("This will be used for grouping data in pages.");
        }
    }
}
