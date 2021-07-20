namespace Data.Detection
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;

    public class DetectionRepository : IDetectionRepository
    {
        private readonly Context _context;

        public DetectionRepository(Context context) => _context = context;

        public IEnumerable<MDetection> ByParameter() => _context.Set<EDetection>()
            .ToList()
            .Select(DetectionFactory.MakeModel);
    }
}
