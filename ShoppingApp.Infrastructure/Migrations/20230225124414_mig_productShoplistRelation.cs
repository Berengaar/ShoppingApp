using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingApp.Infrastructure.Migrations
{
    public partial class mig_productShoplistRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shoplists_ShoplistId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ShoplistId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shoplists_ShoplistId",
                table: "Products",
                column: "ShoplistId",
                principalTable: "Shoplists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shoplists_ShoplistId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ShoplistId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shoplists_ShoplistId",
                table: "Products",
                column: "ShoplistId",
                principalTable: "Shoplists",
                principalColumn: "Id");
        }
    }
}
