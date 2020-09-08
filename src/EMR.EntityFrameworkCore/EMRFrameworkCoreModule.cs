// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EMRFrameworkCoreModule.cs" company="EMR.EntityFrameworkCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EMR.Domain;
using EMR.Domain.Configurations;

using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore
{
    /// <summary>
    /// Class EMRFrameworkCoreModule.
    /// Implements the <see cref="Volo.Abp.Modularity.AbpModule" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Modularity.AbpModule" />
    /// <remarks>Will Wu</remarks>
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
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
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