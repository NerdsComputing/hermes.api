namespace Presentation.Camera.Register
{
    using System;
    using global::GraphQL;
    using global::GraphQL.Resolvers;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using Presentation.Camera.Common.Types;
    using Presentation.Camera.Register.Types;

    public static class Factory
    {
        public static FieldType Make(IServiceProvider provider)
        {
             return new ()
             {
                 Name = "registerCamera",
                 Description = "Registers a camera",
                 Type = typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TCamera>>>),
                 Arguments = MakeArguments(),
                 Resolver = new FuncFieldResolver<TRegisterCamera, object>(MakeResolver(provider)),
             };
        }

        private static Func<IResolveFieldContext<TRegisterCamera>, object> MakeResolver(IServiceProvider provider)
        {
            return input => provider.GetService<IResolver>().Execute(input);
        }

        private static QueryArguments MakeArguments() => new (new QueryArgument(
            typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TRegisterCamera>>>))
        {
            Name = "input",
        });
    }
}
