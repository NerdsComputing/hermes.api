namespace Business.Camera.Common.Repositories
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Fetching.Models;
    using Business.Camera.Register.Models;

    public interface ICameraRepository
    {
        public IEnumerable<MCamera> Insert(IEnumerable<MRegisterCamera> input);

        public IEnumerable<MCamera> ByInput(MRegisterCamera camera);

        public IEnumerable<MCamera> ByParameter(PCamera parameter);
    }
}
