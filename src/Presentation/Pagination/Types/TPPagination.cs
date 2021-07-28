namespace Presentation.Pagination.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Pagination;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public sealed class TPPagination : ObjectGraphType<PPagination>
    {
        public TPPagination()
        {
            Field(pagination => pagination.PageSize).Description("This is the page size");
            Field(pagination => pagination.PageIndex).Description("This is the page index");
        }
    }
}
