namespace Data.Camera
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Camera.Common.Models;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Register.Models;

    public class CameraRepository : ICameraRepository
    {
        private readonly Context _context;

        public CameraRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<MCamera> Insert(IEnumerable<MRegisterCamera> input) => input
            .Select(camera => CameraFactory.MakeEntity(camera))
            .Select(InsertCamera)
            .Select(CameraFactory.MakeModel)
            .ToList();

        private ECamera InsertCamera(ECamera entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
