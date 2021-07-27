namespace Presentation.Detection.Creating
{
    using System;
    using global::GraphQL;
    using global::GraphQL.Resolvers;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.Detection.Common.Types;
    using Presentation.Detection.Creating.Types;

    public static class Factory
    {
        public static FieldType Make(IServiceProvider provider)
        {
            return new ()
            {
                Name = "createDetection",
                Description = "Creates a detection",
                Type = typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TDetection>>>),
                Arguments = MakeArguments(),
                Resolver = new FuncFieldResolver<TCreateDetection, object>(MakeResolver(provider)),
            };
        }

        private static Func<IResolveFieldContext<TCreateDetection>, object> MakeResolver(IServiceProvider provider)
        {
            return input => provider.GetService<IResolver>().Execute(input);
        }

        private static QueryArguments MakeArguments() => new (new QueryArgument(
            typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TCreateDetection>>>))
        {
            Name = "input",
        });
    }
}
