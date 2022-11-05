using CacheTestes.Caches.TesteIMemoryCache;
using Microsoft.AspNetCore.Mvc;

namespace CacheTestes.Controllers
{
    [ApiController]
    [Route("cache/teste")]
    public class TesteCacheController : ControllerBase
    {
        private readonly EntityIMemoryCache _imemoryCache;

        public TesteCacheController(EntityIMemoryCache imemoryCache)
        {
            _imemoryCache = imemoryCache;
        }

        [HttpGet("imemory-cache")]
        public IActionResult GetEntityIMemoryCache()
        {
            Entity[] ret;

            ret = _imemoryCache.GetEntityCache();

            if(ret is null || !ret.Any())
            {
                // Aqui chama o repositório
                ret = new Entity[]
                {
                    new Entity{ Id = 1, Descricao = "Entity-1"},
                    new Entity{ Id = 2, Descricao = "Entity-2"},
                    new Entity{ Id = 3, Descricao = "Entity-3"}
                };
                // Adiciona no cache
                _imemoryCache.AddEntityCache(ret);
            }
            return Ok(ret);
        }
    }
}