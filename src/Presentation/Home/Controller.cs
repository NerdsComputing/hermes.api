namespace Presentation.Home
{
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    [Route("status")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("version")]
        public static string Get()
        {
            return Assembly.GetExecutingAssembly().FullName;
        }
    }
}
