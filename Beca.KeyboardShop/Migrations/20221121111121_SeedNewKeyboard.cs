using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.KeyboardShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewKeyboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Keyboards",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, 2, "An ergonomic and sophisticated keyboard that will give you a great gaming experience.", "Forgeon Clutch 60% Switch Brown", 99.989999999999995 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Keyboards",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
