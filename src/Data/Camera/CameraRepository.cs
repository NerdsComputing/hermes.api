namespace Data.Camera
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Camera.Common.Models;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Fetching.Models;
    using Business.Camera.Register.Models;
    using Business.Pagination;
    using Business.Pagination.Models;
    using Data.Camera.Filtering;

    public class CameraRepository : ICameraRepository
    {
        private readonly Context _context;
        private readonly ICameraFilter _cameraFilter;
        private readonly ISeedFilter _seedFilter;
        private readonly ICreatePagination<ECamera> _pagination;

        public CameraRepository(Context context, ICameraFilter cameraFilter, ISeedFilter seedFilter, ICreatePagination<ECamera> pagination)
        {
            _context = context;
            _cameraFilter = cameraFilter;
            _seedFilter = seedFilter;
            _pagination = pagination;
            _seedFilter = seedFilter;
        }

        public IEnumerable<MCamera> Insert(IEnumerable<MRegisterCamera> input) => input
            .Select(CameraFactory.MakeEntity)
            .Select(InsertCamera)
            .Select(CameraFactory.MakeModel)
            .ToList();

        public MPagination<MCamera> ByParameter(PCamera parameter)
        {
            var cameras = _context.Set<ECamera>();
            var cameraFilters = _cameraFilter.With(parameter).Execute(cameras);
            var cameraPagination = _pagination.With(parameter.Pagination).Execute(cameraFilters);
            return CameraFactory.MakePaginationModel(cameraPagination);
        }

        public IEnumerable<MCamera> ByInput(MRegisterCamera camera)
        {
            var cameras = _context.Set<ECamera>();

            return _seedFilter.With(camera)
                .Execute(cameras)
                .ToList()
                .Select(CameraFactory.MakeModel);
        }

        private ECamera InsertCamera(ECamera entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
