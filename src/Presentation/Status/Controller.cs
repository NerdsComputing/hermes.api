namespace Presentation.Status
{
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    [Route("status")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("version")]
        public IActionResult Version() => Ok(Assembly.GetExecutingAssembly().FullName);
    }
}
