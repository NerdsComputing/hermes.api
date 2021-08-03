namespace Presentation.GraphQL.Base
{
    using Newtonsoft.Json.Linq;

    public class Dto
    {
        public string Query { get; set; }

        public JObject Variables { get; set; }
    }
}
