namespace Presentation.Detection.Fetching.Types
{
    using Business.Detection.Fetching.Models;
    using global::GraphQL.Types;

    public class TScoreFilter : InputObjectGraphType<MScoreFilter>
    {
        public TScoreFilter()
        {
            Name = "ScoreFilter";
            Description = "This will be used for filtering the detections by score";

            Field(score => score.LesserEqualThan, true).Description("Detections will have the score lesser than this value");
            Field(score => score.GreaterEqualThan, true).Description("Detections will have the score greater than this value");
        }
    }
}
