//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore
// FileName : WQHBlogDbContextModelCreatingExtensions
//
// Created by : Will.Wu at 2020/8/4 15:41:03
//
//
//========================================================================

using Microsoft.EntityFrameworkCore;

using Volo.Abp;

namespace EMR.EntityFrameworkCore
{
    public static class EMRDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

        }
    }
}