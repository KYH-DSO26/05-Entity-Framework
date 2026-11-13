using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FailSafeRentals.ConsoleApp.Migrations;

/// <inheritdoc />
public partial class _20261113120604_HardenSchemaAndFeatures : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Rentals_Customers_CustomerId",
            table: "Rentals");

        migrationBuilder.AlterColumn<string>(
            name: "RegistrationNumber",
            table: "Vehicles",
            type: "nvarchar(10)",
            maxLength: 10,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Model",
            table: "Vehicles",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<decimal>(
            name: "DailyRate",
            table: "Vehicles",
            type: "decimal(10,2)",
            precision: 10,
            scale: 2,
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "decimal(18,2)");

        migrationBuilder.AlterColumn<string>(
            name: "Brand",
            table: "Vehicles",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedAt",
            table: "Rentals",
            type: "datetime2",
            nullable: false,
            defaultValueSql: "GETUTCDATE()");

        migrationBuilder.CreateTable(
            name: "ExtraFeatures",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ExtraFeatures", x => x.Id);
            });

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
            name: "IX_Vehicles_RegistrationNumber",
            table: "Vehicles",
            column: "RegistrationNumber",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_ExtraFeaturesVehicle_VehiclesId",
            table: "ExtraFeaturesVehicle",
            column: "VehiclesId");

        migrationBuilder.AddForeignKey(
            name: "FK_Rentals_Customers_CustomerId",
            table: "Rentals",
            column: "CustomerId",
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Rentals_Customers_CustomerId",
            table: "Rentals");

        migrationBuilder.DropTable(
            name: "ExtraFeaturesVehicle");

        migrationBuilder.DropTable(
            name: "ExtraFeatures");

        migrationBuilder.DropIndex(
            name: "IX_Vehicles_RegistrationNumber",
            table: "Vehicles");

        migrationBuilder.DropColumn(
            name: "CreatedAt",
            table: "Rentals");

        migrationBuilder.AlterColumn<string>(
            name: "RegistrationNumber",
            table: "Vehicles",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(10)",
            oldMaxLength: 10);

        migrationBuilder.AlterColumn<string>(
            name: "Model",
            table: "Vehicles",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(50)",
            oldMaxLength: 50);

        migrationBuilder.AlterColumn<decimal>(
            name: "DailyRate",
            table: "Vehicles",
            type: "decimal(18,2)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "decimal(10,2)",
            oldPrecision: 10,
            oldScale: 2);

        migrationBuilder.AlterColumn<string>(
            name: "Brand",
            table: "Vehicles",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(50)",
            oldMaxLength: 50);

        migrationBuilder.AddForeignKey(
            name: "FK_Rentals_Customers_CustomerId",
            table: "Rentals",
            column: "CustomerId",
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
