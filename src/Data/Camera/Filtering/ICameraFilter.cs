namespace Data.Camera.Filtering
{
    using System.Linq;
    using Business;
    using Business.Camera.Fetching.Models;

    public interface ICameraFilter : ICommand<IQueryable<ECamera>, IQueryable<ECamera>>
    {
        ICameraFilter With(PCamera parameter);
    }
}
