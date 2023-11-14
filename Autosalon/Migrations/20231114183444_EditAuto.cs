using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autosalon.Migrations
{
    /// <inheritdoc />
    public partial class EditAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.AddColumn<int>(
                name: "AutoId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auto_OperationId",
                table: "Auto",
                column: "OperationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auto_Operations_OperationId",
                table: "Auto",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auto_Operations_OperationId",
                table: "Auto");

            migrationBuilder.DropIndex(
                name: "IX_Auto_OperationId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "AutoId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Auto");

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.id);
                });
        }
    }
}
