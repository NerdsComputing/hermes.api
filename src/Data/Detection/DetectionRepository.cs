namespace Data.Detection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Models;
    using Business.Detection.Fetching.Models;
    using Business.Pagination;
    using Business.Pagination.Models;
    using Data.Detection.Filtering;
    using Microsoft.EntityFrameworkCore;

    public class DetectionRepository : IDetectionRepository
    {
        private readonly Context _context;
        private readonly IDetectionFilter _filter;
        private readonly ICreatePagination<EDetection> _pagination;

        public DetectionRepository(Context context, IDetectionFilter filter, ICreatePagination<EDetection> pagination)
        {
            _context = context;
            _filter = filter;
            _pagination = pagination;
        }

        public MPagination<MDetection> ByParameter(PDetection parameter)
        {
            var detections = _context.Set<EDetection>()
                .Include(entity => entity.Camera);

            var filterDetections = _filter.With(parameter).Execute(detections);
            var pagination = _pagination.With(parameter.Pagination).Execute(filterDetections);
            return DetectionFactory.MakePaginationModel(pagination);
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
            .Where(entity => detection.Class == entity.Class && Math.Abs(detection.Score - entity.Score) < 0.00001)
            .ToList()
            .Select(DetectionFactory.MakeModel);
    }
}
