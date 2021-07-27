namespace Business.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Register.Models;

    public class CameraSeed : ISeed
    {
        private readonly ICameraRepository _repository;
        private readonly IDataFactory _dataFactory;

        public CameraSeed(ICameraRepository repository, IDataFactory dataFactory)
        {
            _repository = repository;
            _dataFactory = dataFactory;
        }

        public void Execute()
        {
            var missingCameras = MissingCameras().ToList();
            _repository.Insert(missingCameras);
        }

        private IEnumerable<MRegisterCamera> MissingCameras() => _dataFactory
            .Make<MRegisterCamera>("cameras.json")
            .Where(cameras =>
            {
                var one = _repository.ByInput(cameras).ToList();
                return !_repository.ByInput(cameras).Any();
            });
    }
}
