namespace Presentation.GraphQL.Base
{
    using global::GraphQL.Types;

    public class Mutation : ObjectGraphType
    {
        public Mutation()
        {
            Name = "Mutation";
            Field(typeof(StringGraphType), "BasicMutation", "Mutation description", null, _ => "Mutation");
        }
    }
}
