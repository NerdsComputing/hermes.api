namespace Business.Detection.Repositories
{
    using System.Collections.Generic;
    using Business.Detection.Models;

    public interface IDetection
    {
        public IEnumerable<MDetection> All();
    }
}
