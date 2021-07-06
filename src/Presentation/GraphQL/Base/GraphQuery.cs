using System.Collections.Generic;

namespace Presentation.GraphQL.Base
{
    public class GraphQuery
    {
        public string Query { get; set; }

        public Dictionary<string, object> Variables { get; set; }
    }
}
