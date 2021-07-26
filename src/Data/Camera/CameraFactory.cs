namespace Data.Camera
{
    using Business.Camera.Common.Models;
    using Business.Camera.Register.Models;

    public static class CameraFactory
    {
        public static MCamera MakeModel(ECamera entity) => new ()
        {
            Id = entity.Id,
            Latitude = entity.Latitude,
            Longitude = entity.Longitude,
        };

        public static ECamera MakeEntity(MRegisterCamera model) => new ECamera()
        {
            Id = model.Id,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
        };
    }
}
