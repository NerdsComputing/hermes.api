namespace Business.Detection.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;

    public interface IGetDetection : ICommand<Nothing, IEnumerable<MDetection>>
    {
    }
}
