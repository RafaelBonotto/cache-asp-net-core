using Microsoft.Extensions.Caching.Memory;

namespace CacheTestes.Caching.TesteIMemoryCache
{
    public class EntityIMemoryCache
    {
        private readonly IMemoryCache _cache;
        public const string KEY_ENTITY_CACHE = "Entity-Cache";

        public EntityIMemoryCache(IMemoryCache cache)
            => _cache = cache;

        public void AddEntityCache(Entity[] ent)
        {
            var options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12)
            };

            _cache.Set<Entity[]>(
                key: KEY_ENTITY_CACHE, 
                value: ent,
                options: options);
        }

        public Entity[] GetEntityCache()
        {
            if(!_cache.TryGetValue(KEY_ENTITY_CACHE, out Entity[] entities))
                return entities;

            return _cache.Get<Entity[]>(key: KEY_ENTITY_CACHE);
        }
    }
}
