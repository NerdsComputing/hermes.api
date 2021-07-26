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
            var missingCameras = MissingCameras();
            _repository.Insert(missingCameras);
        }

        private IEnumerable<MRegisterCamera> MissingCameras()
        {
            return _dataFactory.Make<MRegisterCamera>("cameras.json")
                .Where(cameras => !_repository.ByInput(cameras).Any());
        }
    }
}
