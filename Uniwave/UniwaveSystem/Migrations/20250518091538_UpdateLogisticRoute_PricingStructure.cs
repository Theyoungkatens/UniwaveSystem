using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniwaveSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogisticRoute_PricingStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "LogisticRoutes",
                newName: "ExtraPricePer0_1Kg");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ShippingOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BasePricePerKg",
                table: "LogisticRoutes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShippingOrders");

            migrationBuilder.DropColumn(
                name: "BasePricePerKg",
                table: "LogisticRoutes");

            migrationBuilder.RenameColumn(
                name: "ExtraPricePer0_1Kg",
                table: "LogisticRoutes",
                newName: "Price");
        }
    }
}
