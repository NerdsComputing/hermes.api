namespace Presentation.Camera.Register.Types
{
    using Business.Camera.Register.Models;
    using global::GraphQL.Types;

    public sealed class TRegisterCamera : InputObjectGraphType<MRegisterCamera>
    {
        public TRegisterCamera()
        {
            Field(camera => camera.Id).Description("This is the camera id.");
            Field(camera => camera.Latitude).Description("This is the latitude at which the camera is placed.");
            Field(camera => camera.Longitude).Description("This is the longitude at which the camera is placed.");
        }
    }
}
