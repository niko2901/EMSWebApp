using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class StudentNumberUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registered_EventId",
                table: "Registered");

            migrationBuilder.AlterColumn<string>(
                name: "StudentNumber",
                table: "Registered",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.Sql(@"
                UPDATE [Registered]
                SET [StudentNumber] = CONCAT('LEGACY-', CAST([Id] AS NVARCHAR(36)))
                WHERE [StudentNumber] = '' OR [StudentNumber] IS NULL;
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Registered_EventId_StudentNumber",
                table: "Registered",
                columns: new[] { "EventId", "StudentNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registered_EventId_StudentNumber",
                table: "Registered");

            migrationBuilder.AlterColumn<string>(
                name: "StudentNumber",
                table: "Registered",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Registered_EventId",
                table: "Registered",
                column: "EventId");
        }
    }
}
