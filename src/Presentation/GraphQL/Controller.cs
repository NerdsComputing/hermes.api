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
        private readonly Schema _schema;

        public Controller(Schema schema) => _schema = schema;


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dto query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(configure =>
            {
                configure.Schema = _schema;
                configure.Query = query.Query;
                configure.Inputs = query.Variables.ToInputs();
            }).ConfigureAwait(false);

            if(result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            var json = await new DocumentWriter().WriteToStringAsync(result);
            return Ok(json);
        }
    }
}
