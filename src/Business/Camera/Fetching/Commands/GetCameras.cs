namespace Business.Camera.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Fetching.Models;

    public class GetCameras : IGetCameras
    {
        private readonly ICameraRepository _repository;

        public GetCameras(ICameraRepository repository) => _repository = repository;

        public IEnumerable<MCamera> Execute(PCamera input) => _repository.ByParameter(input);
    }
}
