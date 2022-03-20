using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoppers_BackEnd_Final.Migrations
{
    public partial class UpdateHeroTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Heroes");

            migrationBuilder.AddColumn<string>(
                name: "Title1",
                table: "Heroes",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Heroes",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title1",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Heroes");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Heroes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
