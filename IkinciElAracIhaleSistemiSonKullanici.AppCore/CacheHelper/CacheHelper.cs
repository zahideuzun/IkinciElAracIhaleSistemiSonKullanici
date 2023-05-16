using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.CacheHelper
{
    public class CacheHelper
    {
        private readonly IMemoryCache _cache;

        public CacheHelper(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// cachede olan veriyi cachekey parametresi ile donduren metot.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public List<T> GetCachedList<T>(string cacheKey)
        {
            if (_cache.TryGetValue(cacheKey, out object cachedValue))
            {
                if (cachedValue is Task<List<T>> task)
                {
                    return task.GetAwaiter().GetResult();
                }
                if (cachedValue is List<T> list)
                {
                    return list;
                }
            }

            return null; 
        }


        /// <summary>
        /// Cachede task list tipinde veri tutan base metot.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="createListFunc"></param>
        /// <param name="cacheDuration"></param>
        /// <returns></returns>
        public async Task<List<T>> CreateAndCacheList<T>(string cacheKey, Func<Task<List<T>>> createListFunc, TimeSpan cacheDuration)
        {
            
            var newList = await createListFunc();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(cacheDuration); 
            _cache.Set(cacheKey, Task.FromResult(newList), cacheOptions);

            return newList;
        }

    }
}
