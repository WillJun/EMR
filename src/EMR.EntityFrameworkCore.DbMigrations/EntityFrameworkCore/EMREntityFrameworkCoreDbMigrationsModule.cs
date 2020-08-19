//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.DbMigrations
// FileName : WQHBlogEntityFrameworkCoreDbMigrationsModule
//
// Created by : Will.Wu at 2020/8/4 15:57:04
//
//
//========================================================================
using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Modularity;

namespace EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
          typeof(EMRFrameworkCoreModule)
      )]
    public class EMREntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EMRMigrationsDbContext>();
        }
    }
}