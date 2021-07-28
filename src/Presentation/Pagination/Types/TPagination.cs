namespace Presentation.Pagination.Types
{
    using System.Diagnostics.CodeAnalysis;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class TPagination<TGraphType> : ObjectGraphType<object> where TGraphType : IGraphType
    {
        public TPagination()
        {
            Name = $"{typeof(TGraphType).Name}Pagination";
            Description = "A pagination used to extract a page collection of items from server.";

            Field<NonNullGraphType<IntGraphType>>("pageIndex", "The index of the page (starts from 0).");
            Field<NonNullGraphType<IntGraphType>>("pageSize", "The size of the page (starts from 1).");
            Field<NonNullGraphType<IntGraphType>>("totalCount", "The total count of the items.");
            Field<NonNullGraphType<ListGraphType<TGraphType>>>("items", "The items.");
        }
    }
}
