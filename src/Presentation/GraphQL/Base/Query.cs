namespace Presentation.GraphQL.Base
{
    using System.Diagnostics.CodeAnalysis;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class Query : ObjectGraphType
     {
         public Query()
         {
             Name = "Query";
             Field(typeof(StringGraphType), "BasicQuery", "Query description", null, _ => "Query");
         }
     }
}
