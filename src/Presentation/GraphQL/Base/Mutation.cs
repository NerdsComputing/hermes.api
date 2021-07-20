namespace Presentation.GraphQL.Base
{
    using System;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.Detection.Creating.Types;

    public class Mutation : ObjectGraphType
    {
        public Mutation(IServiceProvider provider)
        {
            Name = "mutation";
            Field(typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TCreateDetection>>>),
                "createDetection",
                "Creates a detection",
                resolve: provider.GetService<Detection.Creating.IResolver>().Execute);
        }
    }
}
