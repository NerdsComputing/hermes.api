namespace Business.Pagination.Models
{
    using System.Collections.Generic;

    public class MPagination<TItem>
    {
        public IEnumerable<TItem> Items { get; set; } = new List<TItem>();

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalCount { get; set; }
    }
}
