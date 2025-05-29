using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class NieuwenaamgevingProductklasse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WinkelwagenItems");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Prijs");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Beschrijving");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prijs",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Beschrijving",
                table: "Products",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "WinkelwagenItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Aantal = table.Column<int>(type: "INTEGER", nullable: false),
                    Prijs = table.Column<decimal>(type: "TEXT", nullable: false)
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
        }
    }
}
