//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Caching
// FileName : WQHBlogApplicationCachingExtensions
//
// Created by : Will.Wu at 2020/8/5 13:01:13
//
//
//========================================================================
using System;
using System.Threading.Tasks;

using EMR.ToolKits.Extensions;

using Microsoft.Extensions.Caching.Distributed;

using static EMR.Domain.Shared.EMRConsts;

namespace EMR.Application.Caching
{
    public static class EMRApplicationCachingExtensions
    {
        /// <summary>
        /// 获取或添加缓存
        /// </summary>
        /// <typeparam name="TCacheItem"> </typeparam>
        /// <param name="cache"> </param>
        /// <param name="key"> </param>
        /// <param name="factory"> </param>
        /// <param name="minutes"> </param>
        /// <returns> </returns>
        public static async Task<TCacheItem> GetOrAddAsync<TCacheItem>(this IDistributedCache cache, string key, Func<Task<TCacheItem>> factory, int minutes)
        {
            TCacheItem cacheItem;

            var result = await cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(result))
            {
                cacheItem = await factory.Invoke();

                var options = new DistributedCacheEntryOptions();
                if (minutes != CacheStrategy.NEVER)
                {
                    options.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(minutes);
                }

                await cache.SetStringAsync(key, cacheItem.ToJson(), options);
            }
            else
            {
                cacheItem = result.FromJson<TCacheItem>();
            }

            return cacheItem;
        }
    }
}