// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore.DbMigrations
// Author           : WuJun
// Created          : 09-02-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="20200829065224_init2.cs" company="EMR.EntityFrameworkCore.DbMigrations">
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
    /// Class init2.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// <remarks>Will Wu</remarks>
    public partial class init2 : Migration
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
                name: "emr_TeamDiscount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsDisable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FullAmount = table.Column<double>(type: "double", nullable: false),
                    Operation = table.Column<string>(maxLength: 500, nullable: true),
                    Discount = table.Column<double>(type: "double", nullable: false),
                    Discription = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_TeamDiscount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emr_TeamExpend",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Expend = table.Column<double>(type: "double", nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 200, nullable: true),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_TeamExpend", x => x.Id);
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
                name: "emr_TeamDiscount");

            migrationBuilder.DropTable(
                name: "emr_TeamExpend");
        }
    }
}
