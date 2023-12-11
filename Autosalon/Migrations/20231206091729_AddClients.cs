using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Autosalon.Migrations
{
    /// <inheritdoc />
    public partial class AddClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "PassportNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 5, 55, "Alex", "Moshi", "987444677", "+380559543866" },
                    { 6, 21, "Mrritz", "Luckk", "9812317677", "+380665584093" },
                    { 7, 20, "John", "Moore", "9498843233", "+380669533212" },
                    { 8, 18, "Xenia", "Amoore", "977737677", "+380669543822" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
