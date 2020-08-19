//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.DbMigrations
// FileName : WQHBlogMigrationsDbContext
//
// Created by : Will.Wu at 2020/8/4 15:57:24
//
//
//========================================================================
using Microsoft.EntityFrameworkCore;

using Volo.Abp.EntityFrameworkCore;

namespace EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class EMRMigrationsDbContext : AbpDbContext<EMRMigrationsDbContext>
    {
        public EMRMigrationsDbContext(DbContextOptions<EMRMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}