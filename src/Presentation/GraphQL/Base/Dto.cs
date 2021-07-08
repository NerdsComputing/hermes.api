namespace Presentation.GraphQL.Base
{
    using System.Collections.Generic;

    public class Dto
    {
        public string Query { get; set; }

        public Dictionary<string, object> Variables { get; set; }
    }
}
