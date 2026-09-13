using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedVoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MFeeQ1 = table.Column<int>(type: "int", nullable: false),
                    MFeeQ2 = table.Column<int>(type: "int", nullable: false),
                    WindQ1 = table.Column<int>(type: "int", nullable: false),
                    WindQ2 = table.Column<int>(type: "int", nullable: false),
                    HoodieQ1 = table.Column<int>(type: "int", nullable: false),
                    HoodieQ2 = table.Column<int>(type: "int", nullable: false),
                    TshirtQ1 = table.Column<int>(type: "int", nullable: false),
                    TshirtQ2 = table.Column<int>(type: "int", nullable: false),
                    PoloShirtQ1 = table.Column<int>(type: "int", nullable: false),
                    PoloShirtQ2 = table.Column<int>(type: "int", nullable: false),
                    IdnonRevQ1 = table.Column<int>(type: "int", nullable: false),
                    IdnonRevQ2 = table.Column<int>(type: "int", nullable: false),
                    IdRevQ1 = table.Column<int>(type: "int", nullable: false),
                    IdRevQ2 = table.Column<int>(type: "int", nullable: false),
                    MousePadQ1 = table.Column<int>(type: "int", nullable: false),
                    MousePadQ2 = table.Column<int>(type: "int", nullable: false),
                    CapQ1 = table.Column<int>(type: "int", nullable: false),
                    CapQ2 = table.Column<int>(type: "int", nullable: false),
                    CBLQ1 = table.Column<int>(type: "int", nullable: false),
                    CBLQ2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
