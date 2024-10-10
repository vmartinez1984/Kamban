using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Kamban.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVersion()
        {
            // Obtiene la versión del ensamblado
            var version = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

            return Ok(new { Version = version });
        }
    }
}
