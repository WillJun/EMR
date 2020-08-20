using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace EMR.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class inti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WowTime",
                table: "emr_TeamWows",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WowTime",
                table: "emr_TeamWows");
        }
    }
}