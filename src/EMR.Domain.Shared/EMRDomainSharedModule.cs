//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.Shared
// FileName : WQHBlogDomainSharedModule
//
// Created by : Will.Wu at 2020/7/29 15:32:49
//
//
//========================================================================

using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace EMR.Domain.Shared
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class EMRDomainSharedModule : AbpModule
    {
    }
}