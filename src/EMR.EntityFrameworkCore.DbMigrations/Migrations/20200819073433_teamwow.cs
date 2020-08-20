using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace EMR.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class teamwow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "emr_Users",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "emr_TeamWows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsWow = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emr_TeamWows", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emr_TeamWows");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "emr_Users",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");
        }
    }
}