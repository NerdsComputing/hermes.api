namespace Business.Detection.Repositories
{
    using System.Collections.Generic;
    using Business.Detection.Models;

    public interface IDetectionRepository
    {
        public IEnumerable<MDetection> All();
    }
}
