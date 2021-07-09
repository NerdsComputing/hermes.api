namespace Business.Detection.Common.Repositories
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;

    public interface IDetectionRepository
    {
        public IEnumerable<MDetection> All();
    }
}
