namespace Presentation.GraphQL.Base
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::GraphQL.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class Query : ObjectGraphType
    {
        public Query(IServiceProvider provider)
        {
            Name = "query";
            Description = "All the queries that can be done.";

            AddField(Presentation.Detection.Fetching.Factory.Make(provider));
            AddField(Presentation.Camera.Fetching.Factory.Make(provider));
        }
    }
}
