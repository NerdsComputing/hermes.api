namespace Data.Detection
{
    using Business.Detection.Common.Models;

    public static class DetectionFactory
    {
        public static MDetection MakeModel(EDetection entity) => new MDetection
        {
            Id = entity.Id,
            Class = entity.Class,
            Score = entity.Score,
            Timestamp = entity.Timestamp,
        };
    }
}
