namespace Presentation.Pagination.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Pagination;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPPagination : InputObjectGraphType<PPagination>
    {
        public TPPagination()
        {
            Name = "Pagination";
            Description = "It will be used for fetching data for a single page";

            Field(pagination => pagination.PageSize).Description("This is the page size (starts at 1)");
            Field(pagination => pagination.PageIndex).Description("This is the page index (starts at 0");
        }
    }
}
