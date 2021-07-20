namespace Seeds
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Business.Seeds;
    using Data;
    using Newtonsoft.Json;

    public class DetectionSeed : ISeeds
    {
        private readonly Context _context;

        public DetectionSeed(Context context)
        {
            _context = context;
        }

        public void Execute()
        {
            const string jsonPath = "/home/bianca/Hermes/hermes.api/src/Seeds/Data/detections.json";
            var json = File.ReadAllText(jsonPath);
            List<EDetection> detections = JsonConvert.DeserializeObject<List<EDetection>>(json);

            foreach (var detection in detections.Where(detection => !_context.Detections
                .Any(existingDetection =>
                    existingDetection.Class == detection.Class && existingDetection.Score == detection.Score)))
            {
                _context.Detections.Add(detection);
            }

            _context.SaveChanges();
        }
    }
}
