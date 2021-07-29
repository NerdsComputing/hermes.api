namespace Data.Detection
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Models;
    using Business.Pagination.Models;
    using Data.Camera;

    public static class DetectionFactory
    {
        public static MDetection MakeModel(EDetection entity) => new ()
        {
            Id = entity.Id,
            Class = entity.Class,
            Score = entity.Score,
            Timestamp = entity.Timestamp,
            Camera = CameraFactory.MakeModel(entity.Camera),
        };

        public static EDetection MakeEntity(MCreateDetection model) => new EDetection
        {
            Class = model.Class,
            Score = model.Score,
            Timestamp = model.Timestamp,
            CameraId = model.CameraId,
        };

        public static MPagination<MDetection> MakePaginationModel(MPagination<EDetection> pagination) => new ()
        {
            Items = pagination.Items.Select(MakeModel),
            PageIndex = pagination.PageIndex,
            PageSize = pagination.PageSize,
            TotalCount = pagination.TotalCount,
        };
    }
}
