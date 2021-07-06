using GraphQL.Types;

namespace Presentation.GraphQL.Base
{
    public class Mutation : ObjectGraphType
    {
        public Mutation()
        {
            Name = "Mutation";
            Field(typeof(StringGraphType), "BasicMutation",null, null, x => "Mutation");
        }
    }
}
