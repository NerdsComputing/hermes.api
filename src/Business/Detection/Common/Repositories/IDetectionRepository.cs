namespace Business.Detection.Common.Repositories
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Models;
    using Business.Detection.Fetching.Models;

    public interface IDetectionRepository
    {
        public IEnumerable<MDetection> ByParameter(PDetection parameter);

        public IEnumerable<MDetection> Insert(IEnumerable<MCreateDetection> input);

        public IEnumerable<MDetection> ByInput(MCreateDetection detection);
    }
}
