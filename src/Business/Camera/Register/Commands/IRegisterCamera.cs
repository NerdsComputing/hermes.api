namespace Business.Camera.Register.Commands
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Register.Models;

    public interface IRegisterCamera : ICommand<IEnumerable<MRegisterCamera>, IEnumerable<MCamera>>
    {
    }
}
