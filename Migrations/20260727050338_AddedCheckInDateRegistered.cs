using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedCheckInDateRegistered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Venues_VenueId",
                table: "UserEvents");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "Registered",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Venues_VenueId",
                table: "UserEvents",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_Venues_VenueId",
                table: "UserEvents");

            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "Registered");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Venues_VenueId",
                table: "UserEvents",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
