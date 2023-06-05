using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Anounance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_ApplicationUserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Products_ProductId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteStore_AspNetUsers_ApplicationUserId",
                table: "FavouriteStore");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteStoreList_FavouriteStore_FavouriteStoreId",
                table: "FavouriteStoreList");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteStoreList_Products_ProductId",
                table: "FavouriteStoreList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_ApplicationUserId",
                table: "WishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProduct_Products_ProductId",
                table: "WishListProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProduct_WishList_WishlistId",
                table: "WishListProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListProduct",
                table: "WishListProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList",
                table: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteStoreList",
                table: "FavouriteStoreList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteStore",
                table: "FavouriteStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "WishListProduct",
                newName: "WishListProducts");

            migrationBuilder.RenameTable(
                name: "WishList",
                newName: "WishLists");

            migrationBuilder.RenameTable(
                name: "FavouriteStoreList",
                newName: "FavouriteStoreLists");

            migrationBuilder.RenameTable(
                name: "FavouriteStore",
                newName: "FavouriteStores");

            migrationBuilder.RenameTable(
                name: "CartProduct",
                newName: "CartProducts");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_WishListProduct_WishlistId",
                table: "WishListProducts",
                newName: "IX_WishListProducts_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_WishListProduct_ProductId",
                table: "WishListProducts",
                newName: "IX_WishListProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_ApplicationUserId",
                table: "WishLists",
                newName: "IX_WishLists_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteStoreList_ProductId",
                table: "FavouriteStoreLists",
                newName: "IX_FavouriteStoreLists_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteStoreList_FavouriteStoreId",
                table: "FavouriteStoreLists",
                newName: "IX_FavouriteStoreLists_FavouriteStoreId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteStore_ApplicationUserId",
                table: "FavouriteStores",
                newName: "IX_FavouriteStores_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProducts",
                newName: "IX_CartProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProducts",
                newName: "IX_CartProducts_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ApplicationUserId",
                table: "Carts",
                newName: "IX_Carts_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListProducts",
                table: "WishListProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteStoreLists",
                table: "FavouriteStoreLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteStores",
                table: "FavouriteStores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Anounances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anounances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnounanceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AnounanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnounanceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnounanceItems_Anounances_AnounanceId",
                        column: x => x.AnounanceId,
                        principalTable: "Anounances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnounanceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnounanceItems_AnounanceId",
                table: "AnounanceItems",
                column: "AnounanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AnounanceItems_ProductId",
                table: "AnounanceItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Carts_CartId",
                table: "CartProducts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Products_ProductId",
                table: "CartProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteStoreLists_FavouriteStores_FavouriteStoreId",
                table: "FavouriteStoreLists",
                column: "FavouriteStoreId",
                principalTable: "FavouriteStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteStoreLists_Products_ProductId",
                table: "FavouriteStoreLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteStores_AspNetUsers_ApplicationUserId",
                table: "FavouriteStores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_Products_ProductId",
                table: "WishListProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_WishLists_WishlistId",
                table: "WishListProducts",
                column: "WishlistId",
                principalTable: "WishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId",
                table: "WishLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Carts_CartId",
                table: "CartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Products_ProductId",
                table: "CartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteStoreLists_FavouriteStores_FavouriteStoreId",
                table: "FavouriteStoreLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteStoreLists_Products_ProductId",
                table: "FavouriteStoreLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteStores_AspNetUsers_ApplicationUserId",
                table: "FavouriteStores");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_Products_ProductId",
                table: "WishListProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_WishLists_WishlistId",
                table: "WishListProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_ApplicationUserId",
                table: "WishLists");

            migrationBuilder.DropTable(
                name: "AnounanceItems");

            migrationBuilder.DropTable(
                name: "Anounances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListProducts",
                table: "WishListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteStores",
                table: "FavouriteStores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteStoreLists",
                table: "FavouriteStoreLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts");

            migrationBuilder.RenameTable(
                name: "WishLists",
                newName: "WishList");

            migrationBuilder.RenameTable(
                name: "WishListProducts",
                newName: "WishListProduct");

            migrationBuilder.RenameTable(
                name: "FavouriteStores",
                newName: "FavouriteStore");

            migrationBuilder.RenameTable(
                name: "FavouriteStoreLists",
                newName: "FavouriteStoreList");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameTable(
                name: "CartProducts",
                newName: "CartProduct");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_ApplicationUserId",
                table: "WishList",
                newName: "IX_WishList_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishListProducts_WishlistId",
                table: "WishListProduct",
                newName: "IX_WishListProduct_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_WishListProducts_ProductId",
                table: "WishListProduct",
                newName: "IX_WishListProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteStores_ApplicationUserId",
                table: "FavouriteStore",
                newName: "IX_FavouriteStore_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteStoreLists_ProductId",
                table: "FavouriteStoreList",
                newName: "IX_FavouriteStoreList_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteStoreLists_FavouriteStoreId",
                table: "FavouriteStoreList",
                newName: "IX_FavouriteStoreList_FavouriteStoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Cart",
                newName: "IX_Cart_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProduct",
                newName: "IX_CartProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartProducts_CartId",
                table: "CartProduct",
                newName: "IX_CartProduct_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList",
                table: "WishList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListProduct",
                table: "WishListProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteStore",
                table: "FavouriteStore",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteStoreList",
                table: "FavouriteStoreList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_ApplicationUserId",
                table: "Cart",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Products_ProductId",
                table: "CartProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteStore_AspNetUsers_ApplicationUserId",
                table: "FavouriteStore",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteStoreList_FavouriteStore_FavouriteStoreId",
                table: "FavouriteStoreList",
                column: "FavouriteStoreId",
                principalTable: "FavouriteStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteStoreList_Products_ProductId",
                table: "FavouriteStoreList",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_ApplicationUserId",
                table: "WishList",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProduct_Products_ProductId",
                table: "WishListProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProduct_WishList_WishlistId",
                table: "WishListProduct",
                column: "WishlistId",
                principalTable: "WishList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
