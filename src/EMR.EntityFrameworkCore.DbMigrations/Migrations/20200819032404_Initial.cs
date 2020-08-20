using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace EMR.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial : Migration
    {
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
