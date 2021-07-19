namespace Business.Detection.Creating.Commands
{
    using Business.Detection.Common.Models;
    using Business.Detection.Common.Repositories;
    using Business.Detection.Creating.Models;

    public class CreateDetection : ICreateDetection
    {
        private readonly IDetectionRepository _repository;

        public CreateDetection(IDetectionRepository repository)
        {
            _repository = repository;
        }

        public MDetection Execute(MCreateDetection input) => _repository.Create(input);
    }
}
