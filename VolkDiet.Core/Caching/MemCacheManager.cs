using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Caching
{
    public class MemCacheManager : CacheService, ICacheManager,IDisposable
    {
        private bool _disposed;

        private readonly IMemoryCache _cache;

        public MemCacheManager(IMemoryCache cache)
        {
            _cache = cache;
            _disposed = false;
        }


        public T Get<T>(CachedObject element, Func<T> load)
        {
           
            if (_cache.TryGetValue(element.Key, out T res))
                return res;
            res = load();
            if (res != null)
                Set(element, res);
            return res;
        }

        private void Set(CachedObject element, object value)
        {
            if (element.MinutesInCache <= 0)
                return;
            _cache.Set(element.Key, value, CacheOptions(element));
        }

        public async Task<T> GetAsync<T>(CachedObject element, Func<Task<T>> load)
        {
            if (_cache.TryGetValue(element.Key, out T res))
                return res;
            res = await load();
            if (res != null)
                await SetAsync(element, res);
            return res;
        }

        public Task SetAsync(CachedObject element, object value)
        {
            Set(element, value);
            return Task.CompletedTask;
        }
        private MemoryCacheEntryOptions CacheOptions(CachedObject element)
        {
            return new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(element.MinutesInCache)
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _cache.Dispose();

            _disposed = true;
        }

    }
}
