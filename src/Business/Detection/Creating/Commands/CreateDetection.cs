namespace Business.Detection.Creating.Commands
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Models;

    public class CreateDetection : ICreateDetection
    {
        private readonly IDetectionRepository _repository;

        public CreateDetection(IDetectionRepository repository) => _repository = repository;

        public IEnumerable<MDetection> Execute(IEnumerable<MCreateDetection> input) => _repository.Insert(input);
    }
}
