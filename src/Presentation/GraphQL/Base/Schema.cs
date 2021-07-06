namespace Presentation.GraphQL.Base
{
    public class Schema : global::GraphQL.Types.Schema
    {
        public Schema()
        {
            Mutation = new Mutation();

            Query = new Query();
        }
    }
}
