using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.KeyboardShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedMultipleKeyboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Keyboards",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 3, 1, "The Logitech® K380 Bluetooth® keyboard makes any space minimalist, modern and multi-device.", "Logitech K380", 54.990000000000002 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Keyboards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
