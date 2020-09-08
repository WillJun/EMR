// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore.DbMigrations
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EMRMigrationsDbContext.cs" company="EMR.EntityFrameworkCore.DbMigrations">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;

using Volo.Abp.EntityFrameworkCore;

/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    /// <summary>
    /// Class EMRMigrationsDbContext.
    /// Implements the <see cref="Volo.Abp.EntityFrameworkCore.AbpDbContext{EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore.EMRMigrationsDbContext}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.EntityFrameworkCore.AbpDbContext{EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore.EMRMigrationsDbContext}" />
    /// <remarks>Will Wu</remarks>
    public class EMRMigrationsDbContext : AbpDbContext<EMRMigrationsDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMRMigrationsDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <remarks>Will Wu</remarks>
        public EMRMigrationsDbContext(DbContextOptions<EMRMigrationsDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <remarks>Will Wu</remarks>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}