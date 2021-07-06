using GraphQL.Types;

namespace Presentation.GraphQL.Base
{
    public class GraphSchema : Schema
    {
        public GraphSchema()
        {
            Mutation = new Mutation();
            Mutation.Name = "mutation";

            Query = new Query();
            Query.Name = "query";

        }
    }
}
