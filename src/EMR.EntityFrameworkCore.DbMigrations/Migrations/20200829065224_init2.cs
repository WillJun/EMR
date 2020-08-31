using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMR.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class init2 : Migration
    {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emr_TeamDiscount");

            migrationBuilder.DropTable(
                name: "emr_TeamExpend");
        }
    }
}
