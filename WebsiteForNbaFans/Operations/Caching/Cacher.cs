using Microsoft.Extensions.Caching.Memory;

namespace WebsiteForNbaFans.Operations.Caching
{
    public interface ICacher
    {
        public T Get<T>(string key);
        public void Set<T>(string key, T value, TimeSpan? expiration = null);
        public bool TryGetValue<T>(string key, out T value);
        public void Remove(string key);
    }
    public class Cacher : ICacher
    {
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _defaultCacheOptions;

        public Cacher(IMemoryCache cache)
        {
            _cache = cache;
            _defaultCacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(30))
                .SetAbsoluteExpiration(TimeSpan.FromDays(30));
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void Set<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new MemoryCacheEntryOptions();
            if (expiration.HasValue)
            {
                options.SetAbsoluteExpiration(expiration.Value);
                _cache.Set(key, value, options);
            }
            else
            {
                _cache.Set(key, value, _defaultCacheOptions);
            }
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            return _cache.TryGetValue(key, out value);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
