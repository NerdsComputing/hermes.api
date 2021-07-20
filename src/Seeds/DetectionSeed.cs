namespace Seeds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Business.Seeds;
    using Data;

    public class DetectionSeed : ISeeds
    {
        private readonly Context _context;

        public DetectionSeed(Context context)
        {
            _context = context;
        }

        public void Execute()
        {
            var detections = new List<EDetection>
            {
                new EDetection { Class = "plastic", Score = 10, Timestamp = DateTime.UtcNow },
                new EDetection { Class = "glass", Score = 5, Timestamp = DateTime.UtcNow },
                new EDetection { Class = "bottle", Score = 5, Timestamp = DateTime.UtcNow },
            };

            foreach (var detection in detections.Where(detection => !_context.Detections
                .Any(existingDetection => existingDetection.Class == detection.Class && existingDetection.Score == detection.Score)))
            {
                _context.Detections.Add(detection);
            }

            _context.SaveChanges();
        }
    }
}
