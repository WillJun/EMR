// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="EMRDbContextModelCreatingExtensions.cs" company="EMR.EntityFrameworkCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using EMR.Domain.Shared;
using EMR.Domain.TeamBuilding;

using Microsoft.EntityFrameworkCore;

using Volo.Abp;

using static EMR.Domain.Shared.EMRDbConsts;

/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore
{
    /// <summary>
    /// Class EMRDbContextModelCreatingExtensions.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class EMRDbContextModelCreatingExtensions
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <remarks>Will Wu</remarks>
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Team>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.Team);
                b.HasKey(x => x.Id);
                b.Property(x => x.TeamName).HasMaxLength(200).IsRequired();
                b.Property(x => x.TeamLeader).HasMaxLength(200);
                b.Property(x => x.Logo).HasMaxLength(2000);
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
            builder.Entity<TeamDiscount>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.TeamDiscount);
                b.HasKey(x => x.Id);
                b.Property(x => x.TeamId).HasColumnType("char(36)").IsRequired();
                b.Property(x => x.Discount).HasColumnType("double");
                b.Property(x => x.IsDisable).HasColumnType("tinyint(1)");
                b.Property(x => x.FullAmount).HasColumnType("double");
                b.Property(x => x.Discription).HasMaxLength(500);
                b.Property(x => x.Operation).HasMaxLength(500);
            });
            builder.Entity<TeamExpend>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.TeamExpend);
                b.HasKey(x => x.Id);
                b.Property(x => x.TeamId).HasColumnType("char(36)").IsRequired();
                b.Property(x => x.UserId).HasColumnType("char(36)").IsRequired();
                b.Property(x => x.SerialNumber).HasMaxLength(200);
                b.Property(x => x.Expend).HasColumnType("double");

                b.Property(x => x.CreateTime).HasColumnType("datetime");
                b.Property(x => x.Comment).HasMaxLength(500);
            });

            builder.Entity<Activity>(b =>
            {
                b.ToTable(EMRConsts.DbTablePrefix + DbTableName.Activity);
                b.HasKey(x => x.Id);
                b.Property(x => x.ActivityName).HasMaxLength(500);
                b.Property(x => x.Start_Time).HasColumnType("datetime");
                b.Property(x => x.Finish_Time).HasColumnType("datetime");
                b.Property(x => x.IsStart).HasColumnType("tinyint(1)");
            });
        }
    }
}