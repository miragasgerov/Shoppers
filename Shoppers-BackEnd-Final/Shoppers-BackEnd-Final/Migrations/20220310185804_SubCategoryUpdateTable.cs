using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoppers_BackEnd_Final.Migrations
{
    public partial class SubCategoryUpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubCategories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubCategories");
        }
    }
}
