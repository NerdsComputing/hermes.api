namespace Presentation.GraphQL.Base
{
    using global::GraphQL.Types;

    public static class MutationFactory<TGraphInput, TGraphOutput> where TGraphInput : IGraphType where TGraphOutput : IGraphType
    {
        public static void Make(MutationParameter parameter)
        {
            parameter.TypeObject.Field(typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TGraphOutput>>>),
                parameter.Name,
                parameter.Description,
                MakeArguments(),
                parameter.Resolver);
        }

        private static QueryArguments MakeArguments() => new (new QueryArgument(
            typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TGraphInput>>>))
        {
            Name = "input",
        });
    }
}
