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

using EMR.Domain.Shared;
using EMR.Domain.TeamBuilding;
using Microsoft.EntityFrameworkCore;

using Volo.Abp;
using static EMR.Domain.Shared.EMRDbConsts;

namespace EMR.EntityFrameworkCore
{
    public static class EMRDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Team>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.Team);
                b.HasKey(x => x.Id);
                b.Property(x => x.TeamName).HasMaxLength(200).IsRequired();
                b.Property(x => x.TeamLeader).HasMaxLength(200);
                b.Property(x => x.IsOrganiser).HasColumnType("tinyint(1)");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });

            builder.Entity<User>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.User);
                b.HasKey(x => x.Id);
                b.Property(x => x.Account).HasMaxLength(200).IsRequired();
                b.Property(x => x.Dept).HasMaxLength(200);
                b.Property(x => x.Balance).HasColumnType("double");
                b.Property(x => x.Email).HasMaxLength(200);
                b.Property(x => x.UserName).HasMaxLength(200);
                b.Property(x => x.UserEnName).HasMaxLength(200);
                b.Property(x => x.TeamId).HasColumnType("char(36)");
                b.Property(x => x.IsLeader).HasColumnType("tinyint(1)");
                b.Property(x => x.IsOverspend).HasColumnType("tinyint(1)");
            });

            builder.Entity<SalesQuota>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.SalesQuota);
                b.HasKey(x => x.Id);
                b.Property(x => x.Operator).HasColumnType("char(36)");
                b.Property(x => x.SerialNumber).HasMaxLength(200);
                b.Property(x => x.Income).HasColumnType("double");
                b.Property(x => x.TeamId).HasColumnType("char(36)");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
                b.Property(x => x.Comment).HasMaxLength(500);
            });

            builder.Entity<PersonalRecharge>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.PersonalRecharge);
                b.HasKey(x => x.Id);
                b.Property(x => x.UserId).HasColumnType("char(36)");
                b.Property(x => x.SerialNumber).HasMaxLength(200);
                b.Property(x => x.Amount).HasColumnType("double");
                b.Property(x => x.SourceId).HasColumnType("char(36)");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
                b.Property(x => x.Comment).HasMaxLength(500);
            });

            builder.Entity<PersonalExpenditure>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.PersonalExpenditure);
                b.HasKey(x => x.Id);
                b.Property(x => x.UserId).HasColumnType("char(36)");
                b.Property(x => x.SerialNumber).HasMaxLength(200);
                b.Property(x => x.Expend).HasColumnType("double");
                b.Property(x => x.ExpenditureTeamId).HasColumnType("char(36)");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
                b.Property(x => x.Comment).HasMaxLength(500);
            });

            builder.Entity<TeamWow>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.TeamWow);
                b.HasKey(x => x.Id);
                b.Property(x => x.TeamId).HasColumnType("char(36)").IsRequired();
                b.Property(x => x.UserId).HasColumnType("char(36)").IsRequired();
                b.Property(x => x.IsWow).HasColumnType("tinyint(1)");
                b.Property(x => x.WowTime).HasColumnType("datetime");
            });
        }
    }
}