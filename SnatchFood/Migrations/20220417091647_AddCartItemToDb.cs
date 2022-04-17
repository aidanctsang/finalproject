using Microsoft.EntityFrameworkCore.Migrations;

namespace SnatchFood.Migrations
{
    public partial class AddCartItemToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_OrderDetails_OrderDetailsId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantsRestaurantId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Cart");

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
    }
}
