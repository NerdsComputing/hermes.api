namespace Data.Detection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Models;
    using Business.Detection.Fetching.Models;
    using Data.Detection.Filtering;
    using Microsoft.EntityFrameworkCore;

    public class DetectionRepository : IDetectionRepository
    {
        private readonly Context _context;
        private readonly IDetectionFilter _filter;

        public DetectionRepository(Context context, IDetectionFilter filter)
        {
            _context = context;
            _filter = filter;
        }

        public IEnumerable<MDetection> ByParameter(PDetection parameter)
        {
            var detections = _context.Set<EDetection>()
                .Include(entity => entity.Camera);

            return _filter.With(parameter).Execute(detections)
                .ToList()
                .Select(DetectionFactory.MakeModel);
        }

        public IEnumerable<MDetection> Insert(IEnumerable<MCreateDetection> input) => input
            .Select(DetectionFactory.MakeEntity)
            .Select(InsertDetection)
            .Select(DetectionFactory.MakeModel)
            .ToList();

        private EDetection InsertDetection(EDetection entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<MDetection> ByInput(MCreateDetection detection) => _context.Set<EDetection>()
            .Where(entity => detection.Class == entity.Class && detection.Score == entity.Score)
            .ToList()
            .Select(DetectionFactory.MakeModel);
    }
}
