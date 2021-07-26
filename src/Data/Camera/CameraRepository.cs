namespace Data.Camera
{
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

        public MCamera Insert(MRegisterCamera input)
        {
            var entity = CameraFactory.MakeEntity(input);
            _context.Add(entity);
            _context.SaveChanges();

            return CameraFactory.MakeModel(entity);
        }
    }
}
