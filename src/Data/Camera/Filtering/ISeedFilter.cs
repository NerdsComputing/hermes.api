namespace Data.Camera.Filtering
{
    using System.Linq;
    using Business;
    using Business.Camera.Register.Models;

    public interface ISeedFilter : ICommand<IQueryable<ECamera>, IQueryable<ECamera>>
    {
        ISeedFilter With(MRegisterCamera camera);
    }
}
