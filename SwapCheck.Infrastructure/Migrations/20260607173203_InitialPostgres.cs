using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwapCheck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineName = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    Displacement = table.Column<double>(type: "double precision", nullable: false),
                    CylindersCount = table.Column<int>(type: "integer", nullable: false),
                    Horsepower = table.Column<int>(type: "integer", nullable: false),
                    Torque = table.Column<int>(type: "integer", nullable: false),
                    Aspiration = table.Column<int>(type: "integer", nullable: false),
                    Fuel = table.Column<int>(type: "integer", nullable: false),
                    EngineOrientation = table.Column<int>(type: "integer", nullable: false),
                    TransBoltPattern = table.Column<int>(type: "integer", nullable: false),
                    EngineSize = table.Column<int>(type: "integer", nullable: false),
                    MountPattern = table.Column<int>(type: "integer", nullable: false),
                    RequiresStandaloneECU = table.Column<bool>(type: "boolean", nullable: false),
                    IsPlugAndPlay = table.Column<bool>(type: "boolean", nullable: false),
                    Dimension = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Make = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    MountPattern = table.Column<int>(type: "integer", nullable: false),
                    EngineSize = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwapCompatibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCompatible = table.Column<bool>(type: "boolean", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwapCompatibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwapCompatibilities_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SwapCompatibilities_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwapCompatibilities_EngineId",
                table: "SwapCompatibilities",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapCompatibilities_VehicleId",
                table: "SwapCompatibilities",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwapCompatibilities");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
