namespace Business.Camera.Common.Repositories
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Register.Models;

    public interface ICameraRepository
    {
        public IEnumerable<MCamera> Insert(IEnumerable<MRegisterCamera> input);
    }
}
