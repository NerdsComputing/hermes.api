namespace Business.Detection.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Fetching.Models;
    using Business.Pagination.Models;

    public interface IGetDetection : ICommand<PDetection, MPagination<MDetection>>
    {
    }
}
