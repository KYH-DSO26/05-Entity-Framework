using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FailSafeRentals.ConsoleApp.Migrations;

/// <inheritdoc />
public partial class _20261113124630_SeedExtraFeatures : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ExtraFeaturesVehicle");

        migrationBuilder.CreateTable(
            name: "ExtraFeatureVehicle",
            columns: table => new
            {
                ExtraFeaturesId = table.Column<int>(type: "int", nullable: false),
                VehiclesId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ExtraFeatureVehicle", x => new { x.ExtraFeaturesId, x.VehiclesId });
                table.ForeignKey(
                    name: "FK_ExtraFeatureVehicle_ExtraFeatures_ExtraFeaturesId",
                    column: x => x.ExtraFeaturesId,
                    principalTable: "ExtraFeatures",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ExtraFeatureVehicle_Vehicles_VehiclesId",
                    column: x => x.VehiclesId,
                    principalTable: "Vehicles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ExtraFeatureVehicle_VehiclesId",
            table: "ExtraFeatureVehicle",
            column: "VehiclesId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ExtraFeatureVehicle");

        migrationBuilder.CreateTable(
            name: "ExtraFeaturesVehicle",
            columns: table => new
            {
                ExtraFeaturesId = table.Column<int>(type: "int", nullable: false),
                VehiclesId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ExtraFeaturesVehicle", x => new { x.ExtraFeaturesId, x.VehiclesId });
                table.ForeignKey(
                    name: "FK_ExtraFeaturesVehicle_ExtraFeatures_ExtraFeaturesId",
                    column: x => x.ExtraFeaturesId,
                    principalTable: "ExtraFeatures",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ExtraFeaturesVehicle_Vehicles_VehiclesId",
                    column: x => x.VehiclesId,
                    principalTable: "Vehicles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ExtraFeaturesVehicle_VehiclesId",
            table: "ExtraFeaturesVehicle",
            column: "VehiclesId");
    }
}
