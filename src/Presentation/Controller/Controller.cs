using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
    [Route("status")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("version")]
        public string Get()
        {
            return Assembly.GetExecutingAssembly().FullName;
        }
    }
}