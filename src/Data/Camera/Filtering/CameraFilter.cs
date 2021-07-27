namespace Data.Camera.Filtering
{
    using System.Linq;
    using Business.Camera.Fetching.Models;

    public class CameraFilter : ICameraFilter
    {
        private PCamera _parameter;

        public IQueryable<ECamera> Execute(IQueryable<ECamera> input) =>
            input.Where(entity => _parameter.Ids.Contains(entity.Id));

        public ICameraFilter With(PCamera parameter)
        {
            _parameter = parameter;
            return this;
        }
    }
}
