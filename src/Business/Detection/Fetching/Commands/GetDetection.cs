namespace Business.Detection.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Fetching.Models;
    using Business.Pagination.Models;

    public class GetDetection : IGetDetection
    {
        private readonly IDetectionRepository _repository;

        public GetDetection(IDetectionRepository repository) => _repository = repository;

        public MPagination<MDetection> Execute(PDetection input) => _repository.ByParameter(input);
    }
}
