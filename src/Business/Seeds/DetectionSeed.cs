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
            _repository.Insert(missingDetections);
        }

        private IEnumerable<MCreateDetection> MissingDetections()
        {
            return _dataFactory.Make<MCreateDetection>("detections.json")
                .Where(detections => !_repository.ByInput(detections).Any());
        }
    }
}
