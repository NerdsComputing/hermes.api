namespace Data.Detection
{
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Models;

    public static class DetectionFactory
    {
        public static MDetection MakeModel(EDetection entity) => new MDetection
        {
            Id = entity.Id,
            Class = entity.Class,
            Score = entity.Score,
            Timestamp = entity.Timestamp,
        };

        public static EDetection MakeEntity(MCreateDetection model) => new EDetection
        {
            Class = model.Class,
            Score = model.Score,
            Timestamp = model.Timestamp,
        };
    }
}
