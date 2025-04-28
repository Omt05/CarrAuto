using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarrAuto.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVehicleImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehiculesOccasion",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/vehicles/vehicle1.jpeg");

            migrationBuilder.UpdateData(
                table: "VehiculesOccasion",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/vehicles/vehicle2.jpeg");

            migrationBuilder.UpdateData(
                table: "VehiculesOccasion",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/vehicles/vehicle3.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehiculesOccasion",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/vehicles/toyota-corolla.jpg");

            migrationBuilder.UpdateData(
                table: "VehiculesOccasion",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/vehicles/honda-civic.jpg");

            migrationBuilder.UpdateData(
                table: "VehiculesOccasion",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/vehicles/ford-escape.jpg");
        }
    }
}
