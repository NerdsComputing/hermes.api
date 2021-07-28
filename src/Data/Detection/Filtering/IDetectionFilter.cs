namespace Data.Detection.Filtering
{
    using System.Linq;
    using Business;
    using Business.Detection.Fetching.Models;

    public interface IDetectionFilter : ICommand<IQueryable<EDetection>, IQueryable<EDetection>>
    {
        IDetectionFilter With(PDetection parameter);
    }
}
