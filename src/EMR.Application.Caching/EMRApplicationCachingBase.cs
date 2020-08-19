//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Caching
// FileName : CachingServiceBase
//
// Created by : Will.Wu at 2020/8/5 14:32:01
//
//
//========================================================================

using System.Threading.Tasks;
using EMR.ToolKits.Extensions;
using Microsoft.Extensions.Caching.Distributed;

using Volo.Abp.DependencyInjection;

namespace EMR.Application.Caching
{
    public class CachingServiceBase : ITransientDependency
    {
        public IDistributedCache Cache { get; set; }

        public async Task RemoveAsync(string key, int cursor = 0)
        {
            var scan = await RedisHelper.ScanAsync(cursor);
            var keys = scan.Items;

            if (keys.Any() && key.IsNotNullOrEmpty())
            {
                keys = keys.Where(x => x.StartsWith(key)).ToArray();

                await RedisHelper.DelAsync(keys);
            }
        }
    }

    public interface ICacheRemoveService
    {
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"> </param>
        /// <param name="cursor"> </param>
        /// <returns> </returns>
        Task RemoveAsync(string key, int cursor = 0);
    }
}