using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class YearLevelModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "Registered",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearLevelId",
                table: "Registered",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "YearLevel",
                columns: table => new
                {
                    YearLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearLevel", x => x.YearLevelId);
                });

            migrationBuilder.InsertData(
                table: "YearLevel",
                columns: new[] { "YearLevelId", "Level" },
                values: new object[,]
                {
                    { 1, "1st Year" },
                    { 2, "2nd Year" },
                    { 3, "3rd Year" },
                    { 4, "4th Year" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registered_YearLevelId",
                table: "Registered",
                column: "YearLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registered_YearLevel_YearLevelId",
                table: "Registered",
                column: "YearLevelId",
                principalTable: "YearLevel",
                principalColumn: "YearLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registered_YearLevel_YearLevelId",
                table: "Registered");

            migrationBuilder.DropTable(
                name: "YearLevel");

            migrationBuilder.DropIndex(
                name: "IX_Registered_YearLevelId",
                table: "Registered");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "Registered");

            migrationBuilder.DropColumn(
                name: "YearLevelId",
                table: "Registered");
        }
    }
}
