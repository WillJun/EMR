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

using Microsoft.Extensions.Caching.Distributed;

using Volo.Abp.DependencyInjection;

namespace EMR.Application.Caching
{
    public class CachingServiceBase : ITransientDependency
    {
        public IDistributedCache Cache { get; set; }
    }
}