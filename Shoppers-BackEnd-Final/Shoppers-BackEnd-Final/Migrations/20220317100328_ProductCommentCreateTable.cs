using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoppers_BackEnd_Final.Migrations
{
    public partial class ProductCommentCreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_AppUserId",
                table: "ProductComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_ProductId",
                table: "ProductComments",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductComments");
        }
    }
}
