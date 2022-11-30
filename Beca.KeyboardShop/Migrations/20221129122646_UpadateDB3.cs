using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.KeyboardShop.Migrations
{
    /// <inheritdoc />
    public partial class UpadateDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEEI4UfZ3Jbcvo0tMMEGhw5Lte1tLqXlgUT3gSxuNKOwPmLgG87k8wr15RTa3vWBZbA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOHE7uLvi8V2f8E62l3O9qiAYJjnHrYblLyxcwiMHp9n8adn6owD7uBPnR1ar1PoGA==");
        }
    }
}
