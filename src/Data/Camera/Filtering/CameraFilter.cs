namespace Data.Camera.Filtering
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Camera.Fetching.Models;
    using LinqKit;
    using Microsoft.EntityFrameworkCore;

    public class CameraFilter : ICameraFilter
    {
        private PCamera _parameter;

        public ICameraFilter With(PCamera parameter)
        {
            _parameter = parameter;
            return this;
        }

        public IQueryable<ECamera> Execute(IQueryable<ECamera> input)
        {
            input = MatchId(input);
            input = MatchLesserLatitude(input);
            input = MatchGreaterLatitude(input);
            input = MatchLesserLongitude(input);
            return MatchGreaterLongitude(input);
        }

        private IQueryable<ECamera> MatchId(IQueryable<ECamera> input) => _parameter.Ids != null
            ? MatchByIds(input, _parameter.Ids)
            : input;

        private static IQueryable<ECamera> MatchByIds(IQueryable<ECamera> input, List<string> ids)
        {
            var predicate = PredicateBuilder.New<ECamera>();
            foreach (var id in ids)
            {
                predicate = predicate.Or(entity => EF.Functions.Like(entity.Id, $"%{id}%"));
            }

            return input.Where(predicate);
        }

        private IQueryable<ECamera> MatchLesserLatitude(IQueryable<ECamera> input) =>
            _parameter.Latitude.LesserEqualThan != null
                ? input.Where(camera => camera.Latitude <= _parameter.Latitude.LesserEqualThan)
                : input;

        private IQueryable<ECamera> MatchGreaterLatitude(IQueryable<ECamera> input) =>
            _parameter.Latitude.GreaterEqualThan != null
                ? input.Where(camera => camera.Latitude >= _parameter.Latitude.GreaterEqualThan)
                : input;

        private IQueryable<ECamera> MatchLesserLongitude(IQueryable<ECamera> input) =>
            _parameter.Longitude.LesserEqualThan != null
                ? input.Where(camera => camera.Longitude <= _parameter.Longitude.LesserEqualThan)
                : input;

        private IQueryable<ECamera> MatchGreaterLongitude(IQueryable<ECamera> input) =>
            _parameter.Longitude.GreaterEqualThan != null
                ? input.Where(camera => camera.Longitude >= _parameter.Longitude.GreaterEqualThan)
                : input;
    }
}
