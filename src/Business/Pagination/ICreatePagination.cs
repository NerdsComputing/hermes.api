namespace Business.Pagination
{
    using System.Linq;

    public interface ICreatePagination<TEntity> : ICommand<IQueryable<TEntity>, MPagination<TEntity>>
    {
        ICreatePagination<TEntity> With(PPagination pagination);
    }
}
