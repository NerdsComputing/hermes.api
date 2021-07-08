namespace Presentation.Status
{
    using System.Diagnostics;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    [Route("status")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("version")]
        public IActionResult Version()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = FileVersionInfo.GetVersionInfo(assembly.Location);

            return Ok(new
            {
                @short = version.FileVersion,
                @long = version.ProductVersion,
            });
        }
    }
}
