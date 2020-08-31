﻿// <auto-generated />
using System;
using EMR.EntityFrameworkCore.DbMigrations.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

namespace EMR.EntityFrameworkCore.DbMigrations.Migrations
{
    [DbContext(typeof(EMRMigrationsDbContext))]
    [Migration("20200829065224_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EMR.Domain.TeamBuilding.PersonalExpenditure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<double>("Expend")
                        .HasColumnType("double");

                    b.Property<Guid>("ExpenditureTeamId")
                        .HasColumnType("char(36)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("emr_PersonalExpenditures");
                });

            modelBuilder.Entity("EMR.Domain.TeamBuilding.PersonalRecharge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<Guid>("SourceId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("emr_PersonalRecharges");
                });

            modelBuilder.Entity("EMR.Domain.TeamBuilding.SalesQuota", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<double>("Income")
                        .HasColumnType("double");

                    b.Property<Guid>("Operator")
                        .HasColumnType("char(36)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("emr_SalesQuotas");
                });

            modelBuilder.Entity("EMR.Domain.TeamBuilding.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsOrganiser")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TeamLeader")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("emr_Teams");
                });

            modelBuilder.Entity("EMR.Domain.TeamBuilding.TeamDiscount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<string>("Discription")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<double>("FullAmount")
                        .HasColumnType("double");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Operation")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("emr_TeamDiscount");
                });

            modelBuilder.Entity("EMR.Domain.TeamBuilding.TeamExpend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<double>("Expend")
                        .HasColumnType("double");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("emr_TeamExpend");
                });

            modelBuilder.Entity("EMR.Domain.TeamBuilding.TeamWow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsWow")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("WowTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("emr_TeamWows");
                });

            modelBuilder.Entity("EMR.Domain.TeamBuilding.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<string>("Dept")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<bool>("IsLeader")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOverspend")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserEnName")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("emr_Users");
                });
#pragma warning restore 612, 618
        }
    }
}
