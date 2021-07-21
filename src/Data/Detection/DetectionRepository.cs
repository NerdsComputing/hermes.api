namespace Data.Detection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Models;

    public class DetectionRepository : IDetectionRepository
    {
        private readonly Context _context;

        public DetectionRepository(Context context) => _context = context;

        public IEnumerable<MDetection> ByParameter() => _context.Set<EDetection>()
            .ToList()
            .Select(DetectionFactory.MakeModel);

        public IEnumerable<MDetection> Insert(IEnumerable<MCreateDetection> input) => new List<MDetection>
        {
            new MDetection
            {
                Class = "glass",
                Score = 100,
                Timestamp = DateTime.UtcNow,
            },
        };

        public MDetection Insert(MCreateDetection input)
        {
            var result = _context.Detections.Add(DetectionFactory.MakeEntity(input));
            _context.SaveChanges();
            return DetectionFactory.MakeModel(result.Entity);
        }

        public IEnumerable<MDetection> ByInput(MCreateDetection detection) => _context.Set<EDetection>()
                .Where(entity => detection.Class == entity.Class && detection.Score == entity.Score)
                .ToList()
                .Select(DetectionFactory.MakeModel);
    }
}
