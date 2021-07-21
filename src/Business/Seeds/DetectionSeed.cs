namespace Business.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Models;

    public class DetectionSeed : ISeed
    {
        private readonly IDetectionRepository _repository;
        private readonly IDataFactory _dataFactory;

        public DetectionSeed(IDetectionRepository repository, IDataFactory dataFactory)
        {
            _repository = repository;
            _dataFactory = dataFactory;
        }

        public void Execute()
        {
            var missingDetections = MissingDetections();
            foreach (var missingDetection in missingDetections)
            {
                _repository.Insert(missingDetection);
            }
        }

        private IEnumerable<MCreateDetection> MissingDetections()
        {
            var detections = _dataFactory.Make<MCreateDetection>("detections.json")
                .Where(x => !_repository.ByInput(x).Any());

            return detections;
        }
    }
}
