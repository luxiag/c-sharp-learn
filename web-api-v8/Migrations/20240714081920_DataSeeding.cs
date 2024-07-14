using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapiv8.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_touristRoutesPicture_touristRoutes_TouristRouteId",
                table: "touristRoutesPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_touristRoutesPicture",
                table: "touristRoutesPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_touristRoutes",
                table: "touristRoutes");

            migrationBuilder.RenameTable(
                name: "touristRoutesPicture",
                newName: "TouristRoutesPicture");

            migrationBuilder.RenameTable(
                name: "touristRoutes",
                newName: "TouristRoutes");

            migrationBuilder.RenameIndex(
                name: "IX_touristRoutesPicture_TouristRouteId",
                table: "TouristRoutesPicture",
                newName: "IX_TouristRoutesPicture_TouristRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristRoutesPicture",
                table: "TouristRoutesPicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristRoutes",
                table: "TouristRoutes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("5a4cbd41-f969-46e0-b29f-3ea45006844c"), new DateTime(2024, 7, 14, 8, 19, 20, 217, DateTimeKind.Utc).AddTicks(4127), null, "description", null, "Test", "Test", "Test", 0m, "title", null });

            migrationBuilder.AddForeignKey(
                name: "FK_TouristRoutesPicture_TouristRoutes_TouristRouteId",
                table: "TouristRoutesPicture",
                column: "TouristRouteId",
                principalTable: "TouristRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristRoutesPicture_TouristRoutes_TouristRouteId",
                table: "TouristRoutesPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristRoutesPicture",
                table: "TouristRoutesPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristRoutes",
                table: "TouristRoutes");

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("5a4cbd41-f969-46e0-b29f-3ea45006844c"));

            migrationBuilder.RenameTable(
                name: "TouristRoutesPicture",
                newName: "touristRoutesPicture");

            migrationBuilder.RenameTable(
                name: "TouristRoutes",
                newName: "touristRoutes");

            migrationBuilder.RenameIndex(
                name: "IX_TouristRoutesPicture_TouristRouteId",
                table: "touristRoutesPicture",
                newName: "IX_touristRoutesPicture_TouristRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_touristRoutesPicture",
                table: "touristRoutesPicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_touristRoutes",
                table: "touristRoutes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_touristRoutesPicture_touristRoutes_TouristRouteId",
                table: "touristRoutesPicture",
                column: "TouristRouteId",
                principalTable: "touristRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
