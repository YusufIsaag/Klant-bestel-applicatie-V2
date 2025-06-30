using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PartProduct_Products_ProductsId",
                table: "PartProduct");

            migrationBuilder.DropTable(
                name: "WinkelwagenItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "PartProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PartProduct_ProductsId",
                table: "PartProduct",
                newName: "IX_PartProduct_ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "OrderProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductsProductId");

            migrationBuilder.CreateTable(
                name: "winkelwagenProducts",
                columns: table => new
                {
                    WinkelwagenProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Aantal = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_winkelwagenProducts", x => x.WinkelwagenProductId);
                    table.ForeignKey(
                        name: "FK_winkelwagenProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_winkelwagenProducts_ProductId",
                table: "winkelwagenProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsProductId",
                table: "OrderProduct",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartProduct_Products_ProductsProductId",
                table: "PartProduct",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsProductId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PartProduct_Products_ProductsProductId",
                table: "PartProduct");

            migrationBuilder.DropTable(
                name: "winkelwagenProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "PartProduct",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_PartProduct_ProductsProductId",
                table: "PartProduct",
                newName: "IX_PartProduct_ProductsId");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "OrderProduct",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductsProductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductsId");

            migrationBuilder.CreateTable(
                name: "WinkelwagenItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Aantal = table.Column<int>(type: "INTEGER", nullable: false),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    SessionId = table.Column<string>(type: "TEXT", nullable: false),
                    TotaalBedrag = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinkelwagenItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WinkelwagenItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WinkelwagenItems_ProductId",
                table: "WinkelwagenItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartProduct_Products_ProductsId",
                table: "PartProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
