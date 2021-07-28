namespace Presentation.GraphQL.Base
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Business.Camera.Common.Models;
    using Business.Camera.Fetching.Models;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.Camera.Common.Types;
    using Presentation.Camera.Fetching.Types;
    using Presentation.Detection.Common.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public class Query : ObjectGraphType
    {
        public Query(IServiceProvider provider)
        {
            Name = "query";
            Description = "All the queries that can be done.";

            Field(typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TDetection>>>),
                "detections",
                "Fetch all the existing detections",
                resolve: input => provider.GetService<Detection.Fetching.IResolver>().Execute(input));

            AddField(Presentation.Camera.Fetching.Factory.Make(provider));
        }
    }
}
