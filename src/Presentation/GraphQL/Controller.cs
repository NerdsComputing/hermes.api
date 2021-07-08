namespace Presentation.GraphQL
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using global::GraphQL;
    using global::GraphQL.NewtonsoftJson;
    using Microsoft.AspNetCore.Mvc;
    using Presentation.GraphQL.Base;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    [Route("graphql")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Schema _schema;

        public Controller(Schema schema) => _schema = schema;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dto query)
        {
            var result = await Execute(query).ConfigureAwait(false);
            return await ToActionResult(result).ConfigureAwait(false);
        }

        private async Task<ExecutionResult> Execute(Dto query) => await new DocumentExecuter().ExecuteAsync(configure =>
        {
            configure.Schema = _schema;
            configure.Query = query.Query;
            configure.Inputs = query.Variables.ToInputs();
        }).ConfigureAwait(false);

        private async Task<IActionResult> ToActionResult(ExecutionResult result)
        {
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(await new DocumentWriter().WriteToStringAsync(result).ConfigureAwait(false));
        }
    }
}
