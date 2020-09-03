using Microsoft.EntityFrameworkCore.Migrations;

namespace EMR.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class logo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "emr_Teams",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "emr_Teams");
        }
    }
}
