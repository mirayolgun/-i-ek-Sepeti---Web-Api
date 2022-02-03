using Microsoft.EntityFrameworkCore.Migrations;

namespace CicekSepeti.Data.Migrations
{
    public partial class ciceksepetimigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Desciption = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    UnitsInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Desciption", "Name", "Price", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, "Pembe incili Kutuda Renkli Lisyantuslar", "Tasarım Çiçek", 90m, 1 },
                    { 2, "Mutluluk Kutusu", "Doğum Günü Çiçekleri", 79m, 8 },
                    { 3, "Pembe Papatyalar Çiçek Buketi", "Çiçek Buketleri", 94m, 5 },
                    { 4, "Kar Beyaz Gül ve Lilyum", "Lilyum & Zambak", 108m, 4 },
                    { 5, "100 Kırmızı Gül Çiçek Demeti", "Güller", 200m, 6 }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[] { 2, 2, 3 });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[] { 3, 3, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
