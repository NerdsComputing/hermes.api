using System.Threading.Tasks;
using GraphQL;
using GraphQL.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using Presentation.GraphQL.Base;

namespace Presentation.GraphQL
{
    [Route("graphql")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly GraphSchema _schema;

        public Controller(GraphSchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQuery query)
        {
            var executor = new DocumentExecuter();
            var result = await executor.ExecuteAsync(configure =>
            {
                configure.Schema = _schema;
                configure.Query = query.Query;
                configure.Inputs = query.Variables.ToInputs();
            }).ConfigureAwait(false);

            if(result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            var documentWriter = new DocumentWriter();
            var json = await documentWriter.WriteToStringAsync(result);
            return Ok(json);
        }
    }
}
