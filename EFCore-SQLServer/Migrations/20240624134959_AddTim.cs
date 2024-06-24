using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class AddTim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedTime",
                table: "Books",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "publicTime",
                table: "Books",
                newName: "PublicTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Books",
                newName: "updatedTime");

            migrationBuilder.RenameColumn(
                name: "PublicTime",
                table: "Books",
                newName: "publicTime");
        }
    }
}
