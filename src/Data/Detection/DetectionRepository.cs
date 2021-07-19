namespace Data.Detection
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;

    public class DetectionRepository : IDetectionRepository
    {
        private readonly Context _context;

        public DetectionRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<MDetection> ByParameter()
        {
            var detections = _context.Set<EDetection>();

            var detectionList = new List<MDetection>();
            foreach (var detection in detections)
            {
                var detectionModel = new MDetection
                {
                    Id = detection.Id,
                    Class = detection.Class,
                    Score = detection.Score,
                    Timestamp = detection.Timestamp,
                };
                detectionList.Add(detectionModel);
            }

            return detectionList;
        }
    }
}
