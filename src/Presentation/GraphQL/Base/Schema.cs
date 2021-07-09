namespace Presentation.GraphQL.Base
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class Schema : global::GraphQL.Types.Schema
    {
        public Schema(IServiceProvider provider)
        {
            Mutation = new Mutation();

            Query = new Query(provider);
        }
    }
}
