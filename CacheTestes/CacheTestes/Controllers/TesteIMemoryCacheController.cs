using Microsoft.AspNetCore.Mvc;

namespace CacheTestes.Controllers
{
    [ApiController]
    [Route("imemoryCache")]
    public class TesteIMemoryCacheController : ControllerBase
    {
        public TesteIMemoryCacheController()
        {
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("Hallo World");
        }
    }
}