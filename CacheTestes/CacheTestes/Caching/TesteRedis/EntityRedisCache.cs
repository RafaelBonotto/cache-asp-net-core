using Microsoft.Extensions.Caching.Distributed;

namespace CacheTestes.Caching.TesteRedis
{
    public class EntityRedisCache
    {
        // package => Microsoft.Extensions.Caching.StackExchangeRedis

        private readonly IDistributedCache _cache;

        public EntityRedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task SetAsync(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
