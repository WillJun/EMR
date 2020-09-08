// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore.DbMigrations
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="20200819032404_Initial.cs" company="EMR.EntityFrameworkCore.DbMigrations">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using Microsoft.EntityFrameworkCore.Migrations;

/// <summary>
/// The Migrations namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore.DbMigrations.Migrations
{
    /// <summary>
    /// Class Initial.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// <remarks>Will Wu</remarks>
    public partial class Initial : Migration
    {
        /// <summary>
        /// <para>
        /// Builds the operations that will migrate the database 'up'.
        /// </para>
        /// <para>
        /// That is, builds the operations that will take the database from the state left in by the
        /// previous migration so that it is up-to-date with regard to this migration.
        /// </para>
        /// <para>
        /// This method must be overridden in each class the inherits from <see cref="T:Microsoft.EntityFrameworkCore.Migrations.Migration" />.
        /// </para>
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder" /> that will build the operations.</param>
        /// <remarks>Will Wu</remarks>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emr_PersonalExpenditures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExpenditureTeamId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Expend = table.Column<double>(type: "double", nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 200, nullable: true),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_PersonalExpenditures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emr_PersonalRecharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 200, nullable: true),
                    SourceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_PersonalRecharges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emr_SalesQuotas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 200, nullable: true),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Operator = table.Column<Guid>(type: "char(36)", nullable: false),
                    Income = table.Column<double>(type: "double", nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_SalesQuotas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emr_Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TeamName = table.Column<string>(maxLength: 200, nullable: false),
                    TeamLeader = table.Column<string>(maxLength: 200, nullable: true),
                    IsOrganiser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emr_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(maxLength: 200, nullable: false),
                    UserName = table.Column<string>(maxLength: 200, nullable: true),
                    UserEnName = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Dept = table.Column<string>(maxLength: 200, nullable: true),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: true),
                    IsLeader = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Balance = table.Column<double>(type: "double", nullable: false),
                    IsOverspend = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_Users", x => x.Id);
                });
        }

        /// <summary>
        /// Downs the specified migration builder.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder.</param>
        /// <remarks>Will Wu</remarks>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emr_PersonalExpenditures");

            migrationBuilder.DropTable(
                name: "emr_PersonalRecharges");

            migrationBuilder.DropTable(
                name: "emr_SalesQuotas");

            migrationBuilder.DropTable(
                name: "emr_Teams");

            migrationBuilder.DropTable(
                name: "emr_Users");
        }
    }
}
