namespace Business.Pagination
{
    using System.Linq;
    using Business.Pagination.Models;

    public interface ICreatePagination<TEntity> : ICommand<IQueryable<TEntity>, MPagination<TEntity>>
    {
        ICreatePagination<TEntity> With(PPagination pagination);
    }
}
