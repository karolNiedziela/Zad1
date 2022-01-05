using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Project.API.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> Get<T>(string key)
        {
            var value = await _cache.GetStringAsync(key);

            if (value is not null)
            {
                return JsonSerializer.Deserialize<T>(value)!;
            }

            return default!;
        }

        public async Task<T> Set<T>(string key, T value)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(10),
            };

            await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), options);

            return value;
        }
    }
}
