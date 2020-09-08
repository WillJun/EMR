// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore.DbMigrations
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EMREntityFrameworkCoreDbMigrationsModule.cs" company="EMR.EntityFrameworkCore.DbMigrations">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Modularity;

/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    /// <summary>
    /// Class EMREntityFrameworkCoreDbMigrationsModule.
    /// Implements the <see cref="Volo.Abp.Modularity.AbpModule" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Modularity.AbpModule" />
    /// <remarks>Will Wu</remarks>
    [DependsOn(
          typeof(EMRFrameworkCoreModule)
      )]
    public class EMREntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EMRMigrationsDbContext>();
        }
    }
}