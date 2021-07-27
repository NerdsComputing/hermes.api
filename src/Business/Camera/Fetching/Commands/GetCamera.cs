namespace Business.Camera.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Fetching.Models;

    public class GetCamera : IGetCamera
    {
        private readonly ICameraRepository _repository;

        public GetCamera(ICameraRepository repository) => _repository = repository;

        public IEnumerable<MCamera> Execute(PCamera input) => _repository.ByParameter(input);
    }
}
