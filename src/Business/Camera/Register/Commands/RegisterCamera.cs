namespace Business.Camera.Register.Commands
{
    using Business.Camera.Common.Models;
    using Business.Camera.Common.Repositories;
    using Business.Camera.Register.Models;

    public class RegisterCamera : IRegisterCamera
    {
        private readonly ICameraRepository _repository;

        public RegisterCamera(ICameraRepository repository) => _repository = repository;

        public MCamera Execute(MRegisterCamera input) => _repository.Insert(input);
    }
}
