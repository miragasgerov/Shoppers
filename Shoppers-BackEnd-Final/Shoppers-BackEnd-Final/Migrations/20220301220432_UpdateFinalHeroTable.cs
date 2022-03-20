using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoppers_BackEnd_Final.Migrations
{
    public partial class UpdateFinalHeroTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Heroes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Heroes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
