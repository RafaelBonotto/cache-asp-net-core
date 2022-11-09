using Microsoft.Extensions.Caching.Distributed;

namespace CacheTestes.Caching.TesteRedis
{
    public class EntityRedisCache
    {
        // package => Microsoft.Extensions.Caching.StackExchangeRedis

        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;

        public EntityRedisCache(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600), // Tempo absoluto para expiração
                SlidingExpiration = TimeSpan.FromSeconds(1200),               // Tempo sem acesso para expiração
            };
        }

        public async Task<string> GetAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value, _options);
        }
    }
}
