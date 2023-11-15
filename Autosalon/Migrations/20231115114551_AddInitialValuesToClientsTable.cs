using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Autosalon.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialValuesToClientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "PassportNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 21, "Max", "Stuart", "246898432", "+380994873755" },
                    { 2, 25, "Alice", "Jones", "250953999", "+380509843865" },
                    { 3, 40, "Tom", "Ford", "895487342", "+380504390234" },
                    { 4, 33, "Hanry", "Davis", "987437677", "+380669543866" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
