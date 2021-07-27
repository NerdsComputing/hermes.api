namespace Data.Camera.Filtering
{
    using System.Linq;
    using Business.Camera.Register.Models;
    using Microsoft.EntityFrameworkCore;

    public class SeedFilter : ISeedFilter
    {
        private MRegisterCamera _camera;

        public ISeedFilter With(MRegisterCamera camera)
        {
            _camera = camera;
            return this;
        }

        public IQueryable<ECamera> Execute(IQueryable<ECamera> input)
        {
            input = MatchId(input);
            input = MatchLatitude(input);
            return MatchLongitude(input);
        }

        private IQueryable<ECamera> MatchId(IQueryable<ECamera> input) =>
            string.IsNullOrEmpty(_camera.Id)
                ? input
                : input.Where(item => EF.Functions.Like(item.Id, $"%{_camera.Id}%"));

        private IQueryable<ECamera> MatchLatitude(IQueryable<ECamera> input) =>
            string.IsNullOrEmpty(_camera.Latitude)
                ? input
                : input.Where(item => EF.Functions.Like(item.Latitude, $"%{_camera.Latitude}%"));

        private IQueryable<ECamera> MatchLongitude(IQueryable<ECamera> input) =>
            string.IsNullOrEmpty(_camera.Longitude)
                ? input
                : input.Where(item => EF.Functions.Like(item.Longitude, $"%{_camera.Longitude}%"));
    }
}
