using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedMerchandUserVoting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MerchPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchPrices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MerchPrices",
                columns: new[] { "Id", "Item", "Price" },
                values: new object[,]
                {
                    { 1, "Membership Fee", 20.0 },
                    { 2, "Wind Breaker", 1200.0 },
                    { 3, "Hoodie", 290.0 },
                    { 4, "T-shirt", 290.0 },
                    { 5, "Polo Shirt", 290.0 },
                    { 6, "ID Non-Reversible", 85.0 },
                    { 7, "ID Reversible", 120.0 },
                    { 8, "Mouse Pad", 120.0 },
                    { 9, "Cap", 120.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchPrices");
        }
    }
}
