namespace Presentation.Camera.Fetching.Models
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Camera.Fetching.Models;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPCamera : InputObjectGraphType<PCamera>
    {
        public TPCamera()
        {
            Field(camera => camera.Ids).Description("This is the list of ids");
        }
    }
}
