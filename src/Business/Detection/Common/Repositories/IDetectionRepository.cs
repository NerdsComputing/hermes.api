namespace Business.Detection.Common.Repositories
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Models;

    public interface IDetectionRepository
    {
        public IEnumerable<MDetection> ByParameter();

        public IEnumerable<MDetection> Insert(IEnumerable<MCreateDetection> input);

        public MDetection Insert(MCreateDetection input);

        public IEnumerable<MDetection> ByInput(MCreateDetection detection);
    }
}
