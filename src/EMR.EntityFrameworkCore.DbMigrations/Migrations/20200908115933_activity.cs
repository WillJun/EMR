// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore.DbMigrations
// Author           : WuJun
// Created          : 09-08-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="20200908115933_activity.cs" company="EMR.EntityFrameworkCore.DbMigrations">
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
    /// Class activity.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// <remarks>Will Wu</remarks>
    public partial class activity : Migration
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
                name: "emr_Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityName = table.Column<string>(maxLength: 500, nullable: true),
                    Start_Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Finish_Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStart = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_Activities", x => x.Id);
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
                name: "emr_Activities");
        }
    }
}
