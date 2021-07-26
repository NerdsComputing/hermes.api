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
        private readonly ICameraFilter _filter;

        public CameraRepository(Context context, ICameraFilter filter)
        {
            _context = context;
            _filter = filter;
        }

        public IEnumerable<MCamera> Insert(IEnumerable<MRegisterCamera> input) => input
            .Select(camera => CameraFactory.MakeEntity(camera))
            .Select(InsertCamera)
            .Select(CameraFactory.MakeModel)
            .ToList();

        public IEnumerable<MCamera> ByInput(MRegisterCamera camera) => _context.Set<ECamera>()
            .Where(entity => camera.Id == entity.Id && camera.Latitude == entity.Latitude &&
                             camera.Longitude == entity.Longitude)
            .ToList()
            .Select(CameraFactory.MakeModel);

        public IEnumerable<MCamera> ByParameter(PCamera parameter)
        {
            var cameras = _context.Set<ECamera>();
            return _filter.With(parameter).Execute(cameras)
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
