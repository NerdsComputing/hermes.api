using GraphQL.Types;

namespace Presentation.GraphQL.Base
{
     public class Query : ObjectGraphType
     {
         public Query()
         {
             Name = "Query";
             Field(typeof(StringGraphType), "BasicQuery",null, null, x => "Mutation!");
         }
     }
}