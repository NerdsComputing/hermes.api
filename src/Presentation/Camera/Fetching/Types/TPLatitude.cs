namespace Presentation.Camera.Fetching.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Camera.Fetching.Models;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPLatitude : InputObjectGraphType<PLatitude>
    {
        public TPLatitude()
        {
            Name = "LatitudeFilter";
            Description = "This will be used for filtering the cameras by latitude";

            Field(latitude => latitude.LesserEqualThan, true).Description("Cameras will have the latitude lesser or equal than this value.");
            Field(latitude => latitude.GreaterEqualThan, true).Description("Cameras will have the latitude greater or equal than this value.");
        }
    }
}
