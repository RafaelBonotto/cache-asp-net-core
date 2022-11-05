using Microsoft.Extensions.Caching.Memory;

namespace CacheTestes.Caches.TesteIMemoryCache
{
    public class EntityIMemoryCache
    {
        private readonly IMemoryCache _cache;

        public EntityIMemoryCache(IMemoryCache cache)
            => _cache = cache;

        public void AddCache(List<Entity> ent)
            => _cache.Set<List<Entity>>(key:"Entity-Cache", value: ent);
    }
}
