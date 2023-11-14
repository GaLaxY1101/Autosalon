using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autosalon.Migrations
{
    /// <inheritdoc />
    public partial class AddModelAndAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelDrive = table.Column<int>(type: "int", nullable: false),
                    BodyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    Milage = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auto_Models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auto_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricEngineLinks",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ElectricEngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricEngineLinks", x => new { x.ModelId, x.ElectricEngineId });
                    table.ForeignKey(
                        name: "FK_ElectricEngineLinks_ElectricEngines_ElectricEngineId",
                        column: x => x.ElectricEngineId,
                        principalTable: "ElectricEngines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricEngineLinks_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelTransmissionLink",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTransmissionLink", x => new { x.ModelId, x.TransmissionId });
                    table.ForeignKey(
                        name: "FK_ModelTransmissionLink_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelTransmissionLink_Transmissions_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Transmissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorLinks",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    MotorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorLinks", x => new { x.MotorId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_MotorLinks_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotorLinks_Motors_MotorId",
                        column: x => x.MotorId,
                        principalTable: "Motors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoElectricEngineLink",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    ElectricEngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoElectricEngineLink", x => new { x.AutoId, x.ElectricEngineId });
                    table.ForeignKey(
                        name: "FK_AutoElectricEngineLink_Auto_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Auto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoElectricEngineLink_ElectricEngines_ElectricEngineId",
                        column: x => x.ElectricEngineId,
                        principalTable: "ElectricEngines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoEquipmentLink",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoEquipmentLink", x => new { x.AutoId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_AutoEquipmentLink_Auto_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Auto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoEquipmentLink_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoMotorLink",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    MotorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMotorLink", x => new { x.AutoId, x.MotorId });
                    table.ForeignKey(
                        name: "FK_AutoMotorLink_Auto_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Auto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMotorLink_Motors_MotorId",
                        column: x => x.MotorId,
                        principalTable: "Motors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auto_ModelID",
                table: "Auto",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Auto_TransmissionId",
                table: "Auto",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoElectricEngineLink_ElectricEngineId",
                table: "AutoElectricEngineLink",
                column: "ElectricEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoEquipmentLink_EquipmentId",
                table: "AutoEquipmentLink",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMotorLink_MotorId",
                table: "AutoMotorLink",
                column: "MotorId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricEngineLinks_ElectricEngineId",
                table: "ElectricEngineLinks",
                column: "ElectricEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorLinks_ModelId",
                table: "MotorLinks",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoElectricEngineLink");

            migrationBuilder.DropTable(
                name: "AutoEquipmentLink");

            migrationBuilder.DropTable(
                name: "AutoMotorLink");

            migrationBuilder.DropTable(
                name: "ElectricEngineLinks");

            migrationBuilder.DropTable(
                name: "ModelTransmissionLink");

            migrationBuilder.DropTable(
                name: "MotorLinks");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
