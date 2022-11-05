using Microsoft.Extensions.Caching.Memory;

namespace CacheTestes.Caches.TesteIMemoryCache
{
    public class EntityIMemoryCache
    {
        private readonly IMemoryCache _cache;
        private const string KEY_ENTITY_CACHE = "Entity-Cache";

        public EntityIMemoryCache(IMemoryCache cache)
            => _cache = cache;

        public void AddCache(Entity[] ent)
        {
            var options = new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromSeconds(1),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
            };

            _cache.Set<Entity[]>(
                key: KEY_ENTITY_CACHE, 
                value: ent,
                options: options);
        }

        public Entity[] GetEntityCache()
            => _cache.Get<Entity[]>(key: KEY_ENTITY_CACHE);
    }
}
