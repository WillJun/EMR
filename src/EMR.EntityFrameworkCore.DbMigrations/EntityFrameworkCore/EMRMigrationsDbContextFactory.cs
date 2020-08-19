//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.DbMigrations
// FileName : WQHBlogMigrationsDbContextFactory
//
// Created by : Will.Wu at 2020/8/4 15:57:38
//
//
//========================================================================

using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class EMRMigrationsDbContextFactory : IDesignTimeDbContextFactory<EMRMigrationsDbContext>
    {
        public EMRMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EMRMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new EMRMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}