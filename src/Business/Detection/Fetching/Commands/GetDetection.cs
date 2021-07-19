namespace Business.Detection.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;

    public class GetDetection : IGetDetection
    {
        private readonly IDetectionRepository _repository;

        public GetDetection(IDetectionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MDetection> Execute(Nothing input) => _repository.ByParameter();
    }
}
