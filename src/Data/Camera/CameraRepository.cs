namespace Data.Camera
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Camera.Common.Models;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Fetching.Models;
    using Business.Camera.Register.Models;
    using Data.Camera.Filtering;

    public class CameraRepository : ICameraRepository
    {
        private readonly Context _context;
        private readonly ICameraFilter _cameraFilter;
        private readonly ISeedFilter _seedFilter;

        public CameraRepository(Context context, ICameraFilter cameraFilter, ISeedFilter seedFilter)
        {
            _context = context;
            _cameraFilter = cameraFilter;
            _seedFilter = seedFilter;
            _seedFilter = seedFilter;
        }

        public IEnumerable<MCamera> Insert(IEnumerable<MRegisterCamera> input) => input
            .Select(CameraFactory.MakeEntity)
            .Select(InsertCamera)
            .Select(CameraFactory.MakeModel)
            .ToList();

        public IEnumerable<MCamera> ByParameter(PCamera parameter)
        {
            var cameras = _context.Set<ECamera>();
            return _cameraFilter.With(parameter).Execute(cameras)
                .ToList()
                .Select(CameraFactory.MakeModel);
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
