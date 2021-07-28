namespace Presentation.Camera.Fetching
{
    using System;
    using global::GraphQL;
    using global::GraphQL.Resolvers;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.Camera.Common.Types;
    using Presentation.Camera.Fetching.Types;

    public static class Factory
    {
        public static FieldType Make(IServiceProvider provider)
        {
            return new ()
            {
                Name = "cameras",
                Description = "Fetch all the existing cameras",
                Type = typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TCamera>>>),
                Arguments = MakeArguments(),
                Resolver = new FuncFieldResolver<TPCamera, object>(MakeResolver(provider)),
            };
        }

        private static Func<IResolveFieldContext<object>, object> MakeResolver(IServiceProvider provider)
        {
            return input => provider.GetService<IResolver>().Execute(input);
        }

        private static QueryArguments MakeArguments() => new (new QueryArgument<TPCamera>
        {
            Name = "parameter",
            Description = "The parameter used to filter the results.",
        });
    }
}
