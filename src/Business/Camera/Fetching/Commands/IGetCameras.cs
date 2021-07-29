namespace Business.Camera.Fetching.Commands
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Fetching.Models;
    using Business.Pagination.Models;

    public interface IGetCameras : ICommand<PCamera, MPagination<MCamera>>
    {
    }
}
