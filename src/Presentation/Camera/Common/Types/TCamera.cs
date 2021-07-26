namespace Presentation.Camera.Common.Types
{
    using Business.Camera.Common.Models;
    using global::GraphQL.Types;

    public class TCamera : ObjectGraphType<MCamera>
    {
        public TCamera()
        {
            Field(camera => camera.Id).Description("This is the camera id.");
            Field(camera => camera.Latitude).Description("This is the latitude at which the camera is placed.");
            Field(camera => camera.Longitude).Description("This is the longitude at which the camera is placed.");
        }
    }
}
