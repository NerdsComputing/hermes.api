namespace Presentation.Pagination.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Pagination;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPagination<TGraphType> : ObjectGraphType<MPagination<object>> where TGraphType : IGraphType
    {
        public TPagination()
        {
            Name = "Pagination";
            Description = "A pagination used to extract a page collection of items from server.";

            Field(pagination => pagination.Items).Description("These are the items.");
            Field(pagination => pagination.PageIndex).Description("The index of the page (it starts from 0)");
            Field(pagination => pagination.PageSize).Description("This is the page size (it starts from 1).");
            Field(pagination => pagination.TotalCounts).Description("This is the total count of the items.");
        }
    }
}
