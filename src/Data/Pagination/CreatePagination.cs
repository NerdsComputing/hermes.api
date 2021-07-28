namespace Data.Pagination
{
    using System.Collections.Generic;
    using System.Linq;
    using Business.Pagination;
    using Business.Pagination.Models;

    public class CreatePagination<TItem> : ICreatePagination<TItem>
    {
        private PPagination _pagination;

        public ICreatePagination<TItem> With(PPagination pagination)
        {
            _pagination = pagination;
            return this;
        }

        public MPagination<TItem> Execute(IQueryable<TItem> input) => BuildPage(input);

        private MPagination<TItem> BuildPage(IQueryable<TItem> input) => new ()
        {
            Items = GetItems(input),
            PageIndex = _pagination.PageIndex,
            PageSize = _pagination.PageSize,
            TotalCounts = input.Count(),
        };

        private IEnumerable<TItem> GetItems(IQueryable<TItem> input) => input
            .Skip(_pagination.PageIndex * _pagination.PageSize)
            .Take(_pagination.PageSize)
            .ToList();
    }
}
