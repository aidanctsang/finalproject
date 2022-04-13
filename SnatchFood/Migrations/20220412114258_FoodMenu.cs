using Microsoft.EntityFrameworkCore.Migrations;

namespace SnatchFood.Migrations
{
    public partial class FoodMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_OrderDetails_OrderDetailsId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantsRestaurantId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RestaurantsRestaurantId",
                table: "Menu",
                newName: "IX_Menu_RestaurantsRestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_OrderDetailsId",
                table: "Menu",
                newName: "IX_Menu_OrderDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_OrderDetails_OrderDetailsId",
                table: "Menu",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Restaurants_RestaurantsRestaurantId",
                table: "Menu",
                column: "RestaurantsRestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_OrderDetails_OrderDetailsId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Restaurants_RestaurantsRestaurantId",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_RestaurantsRestaurantId",
                table: "Menus",
                newName: "IX_Menus_RestaurantsRestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_OrderDetailsId",
                table: "Menus",
                newName: "IX_Menus_OrderDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_OrderDetails_OrderDetailsId",
                table: "Menus",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RestaurantsRestaurantId",
                table: "Menus",
                column: "RestaurantsRestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
