namespace Business.Camera.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Fetching.Models;

    public interface IGetCamera : ICommand<PCamera, IEnumerable<MCamera>>
    {
    }
}
