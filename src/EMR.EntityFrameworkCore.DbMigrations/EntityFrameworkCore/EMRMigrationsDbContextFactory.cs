// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore.DbMigrations
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EMRMigrationsDbContextFactory.cs" company="EMR.EntityFrameworkCore.DbMigrations">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    /// <summary>
    /// Class EMRMigrationsDbContextFactory.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory{EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore.EMRMigrationsDbContext}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory{EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore.EMRMigrationsDbContext}" />
    /// <remarks>Will Wu</remarks>
    public class EMRMigrationsDbContextFactory : IDesignTimeDbContextFactory<EMRMigrationsDbContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>An instance of <typeparamref name="TContext" />.</returns>
        /// <remarks>Will Wu</remarks>
        public EMRMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EMRMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new EMRMigrationsDbContext(builder.Options);
        }

        /// <summary>
        /// Builds the configuration.
        /// </summary>
        /// <returns>IConfigurationRoot.</returns>
        /// <remarks>Will Wu</remarks>
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}