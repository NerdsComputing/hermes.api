namespace Business.Camera.Register.Commands
{
    using Business.Camera.Common.Models;
    using Business.Camera.Register.Models;

    public interface IRegisterCamera : ICommand<MRegisterCamera, MCamera>
    {
    }
}
