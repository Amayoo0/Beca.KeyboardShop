using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.KeyboardShop.Migrations
{
    /// <inheritdoc />
    public partial class UpadateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOHE7uLvi8V2f8E62l3O9qiAYJjnHrYblLyxcwiMHp9n8adn6owD7uBPnR1ar1PoGA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEKuSOJiCaoc1gpJRoVo7KNCr5HGJmttkUvFzmLvcCuxd6jI2lEdoZRKvQKFFx2vT7Q==");
        }
    }
}
