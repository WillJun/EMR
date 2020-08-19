//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.EntityFrameworkCore
// FileName : WQHBlogFrameworkCoreModule
//
// Created by : Will.Wu at 2020/7/29 15:43:15
//
//
//========================================================================
using EMR.Domain;
using EMR.Domain.Configurations;

using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace EMR.EntityFrameworkCore
{
    [DependsOn(
           typeof(EMRDomainModule),
           typeof(AbpEntityFrameworkCoreModule),
           typeof(AbpEntityFrameworkCoreMySQLModule),
           typeof(AbpEntityFrameworkCoreSqlServerModule),
           typeof(AbpEntityFrameworkCorePostgreSqlModule),
           typeof(AbpEntityFrameworkCoreSqliteModule)
       )]
    public class EMRFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EMRDbContext>(options =>
               {
                   options.AddDefaultRepositories(includeAllEntities: true);
               });
            Configure<AbpDbContextOptions>(options =>
            {
                switch (AppSettings.EnableDb)
                {
                    case "MySQL":
                        options.UseMySQL();
                        break;

                    case "SqlServer":
                        options.UseSqlServer();
                        break;

                    case "PostgreSql":
                        options.UsePostgreSql();
                        break;

                    case "Sqlite":
                        options.UseSqlite();
                        break;

                    default:
                        options.UseMySQL();
                        break;
                }
            });
        }
    }
}