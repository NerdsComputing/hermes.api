namespace Business.Detection.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Fetching.Models;

    public interface IGetDetection : ICommand<PDetection, IEnumerable<MDetection>>
    {
    }
}
