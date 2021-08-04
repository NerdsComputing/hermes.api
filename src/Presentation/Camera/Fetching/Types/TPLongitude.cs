namespace Presentation.Camera.Fetching.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Camera.Fetching.Models;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPLongitude : InputObjectGraphType<PLongitude>
    {
        public TPLongitude()
        {
            Name = "LongitudeFilter";
            Description = "This will be used for filtering the cameras by longitude";

            Field(longitude => longitude.LesserEqualThan, true).Description("Cameras will have the longitude lesser or equal than this value.");
            Field(longitude => longitude.GreaterEqualThan, true).Description("Cameras will have the longitude greater or equal than this value.");
        }
    }
}
