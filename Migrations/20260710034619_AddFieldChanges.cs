using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "UserEvents",
                newName: "Capacity");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "UserEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationStart",
                table: "UserEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationStart",
                table: "UserEvents");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "UserEvents",
                newName: "capacity");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "UserEvents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
