using Flurl.Http;
using Flurl.Http.Configuration;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.Helpers
{
    public class CacheHelper
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;

        public CacheHelper(ILogger<CacheHelper> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task<T> GetCachedDataAsync<T>(string cacheKey, Func<Task<T>> codeBlock, TimeSpan slidingExpiration, TimeSpan absoluteExpiration)
        {
            if (!_cache.TryGetValue(cacheKey, out T cacheEntry))
            {
                cacheEntry = await codeBlock();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(slidingExpiration)
                    .SetAbsoluteExpiration(absoluteExpiration);

                _cache.Set(cacheKey, cacheEntry, cacheOptions);
            }
            return cacheEntry;
        }
    }
}
