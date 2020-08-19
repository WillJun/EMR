//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore
// FileName : WQHBlogDbContext
//
// Created by : Will.Wu at 2020/8/4 15:38:00
//
//
//========================================================================
using Microsoft.EntityFrameworkCore;

using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EMR.EntityFrameworkCore
{
    [ConnectionStringName("MySql")]
    public class EMRDbContext : AbpDbContext<EMRDbContext>
    {
        public EMRDbContext(DbContextOptions<EMRDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }


    }
}