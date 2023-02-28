using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingApp.Infrastructure.Migrations
{
    public partial class mig_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Shoplists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ShoplistCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shoplists_UserId",
                table: "Shoplists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoplistCategories_UserId",
                table: "ShoplistCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_UserId",
                table: "ProductCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Users_UserId",
                table: "ProductCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoplistCategories_Users_UserId",
                table: "ShoplistCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoplists_Users_UserId",
                table: "Shoplists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Users_UserId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoplistCategories_Users_UserId",
                table: "ShoplistCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoplists_Users_UserId",
                table: "Shoplists");

            migrationBuilder.DropIndex(
                name: "IX_Shoplists_UserId",
                table: "Shoplists");

            migrationBuilder.DropIndex(
                name: "IX_ShoplistCategories_UserId",
                table: "ShoplistCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_UserId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shoplists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoplistCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductCategories");
        }
    }
}
