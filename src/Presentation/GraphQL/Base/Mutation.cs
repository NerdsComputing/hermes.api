namespace Presentation.GraphQL.Base
{
    using System;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.Detection.Common.Types;
    using Presentation.Detection.Creating.Types;

    public class Mutation : ObjectGraphType
    {
        public Mutation(IServiceProvider provider)
        {
            Name = "mutation";

            Field(typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TDetection>>>),
                "createDetection",
                "Creates a detection",
                arguments: CreateDetectionArguments(),
                resolve: input => provider.GetService<Detection.Creating.IResolver>().Execute(input));
        }

        private static QueryArguments CreateDetectionArguments() => new (new QueryArgument(
            typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TCreateDetection>>>))
        {
            Name = "input",
        });
    }
}
