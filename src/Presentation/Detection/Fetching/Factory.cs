namespace Presentation.Detection.Fetching
{
    using System;
    using global::GraphQL;
    using global::GraphQL.Resolvers;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.Detection.Common.Types;
    using Presentation.Detection.Fetching.Types;

    public static class Factory
    {
        public static FieldType Make(IServiceProvider provider)
        {
            return new ()
            {
                Name = "detections",
                Description = "Fetch all the existing detections",
                Type = typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TDetection>>>),
                Arguments = MakeArguments(),
                Resolver = new FuncFieldResolver<TPDetection, object>(MakeResolver(provider)),
            };
        }

        private static Func<IResolveFieldContext<object>, object> MakeResolver(IServiceProvider provider)
        {
            return input => provider.GetService<IResolver>().Execute(input);
        }

        private static QueryArguments MakeArguments() => new (new QueryArgument<TPDetection>
        {
            Name = "parameter",
            Description = "The parameter used to filter the results",
        });
    }
}
