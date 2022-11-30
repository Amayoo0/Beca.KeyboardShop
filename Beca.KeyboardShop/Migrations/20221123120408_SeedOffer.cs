using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.KeyboardShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Discounter",
                table: "Keyboards",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OfferInSeconds",
                table: "Keyboards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Keyboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discounter", "OfferInSeconds" },
                values: new object[] { true, 1000 });

            migrationBuilder.UpdateData(
                table: "Keyboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discounter", "OfferInSeconds" },
                values: new object[] { true, 200 });

            migrationBuilder.UpdateData(
                table: "Keyboards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discounter", "OfferInSeconds" },
                values: new object[] { false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discounter",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "OfferInSeconds",
                table: "Keyboards");
        }
    }
}
