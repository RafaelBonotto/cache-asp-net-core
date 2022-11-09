using CacheTestes.Caching.TesteIMemoryCache;
using CacheTestes.Caching.TesteRedis;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CacheTestes.Controllers
{
    [ApiController]
    [Route("cache/teste")]
    public class TesteCacheController : ControllerBase
    {
        private readonly EntityIMemoryCache _imemoryCache;
        private readonly EntityRedisCache _redisCache;
        public const string REDIS_KEY = "REDIS_KEY";

        public TesteCacheController(
            EntityIMemoryCache imemoryCache, 
            EntityRedisCache redisCache)
        {
            _imemoryCache = imemoryCache;
            _redisCache = redisCache;
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

        [HttpGet("redis")]
        public async Task<IActionResult> GetEntityRedis()
        {
            string ret;

            ret = await _redisCache.GetAsync(REDIS_KEY);

            if (string.IsNullOrEmpty(ret))
            {
                // Aqui chama o repositório
                ret = "Id: 1, Descricao: Entity-1";

                var value = JsonConvert.SerializeObject(ret);
                // Adiciona no cache
                await _redisCache.SetAsync(REDIS_KEY, value);
            }
            var resp = JsonConvert.DeserializeObject<dynamic>(ret);
            return Ok(resp);
        }
    }
}