using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentsForeignKeyCorrectly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_services_serviceId",
                table: "appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_services_serviceId",
                table: "appointments",
                column: "serviceId",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_services_serviceId",
                table: "appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_services_serviceId",
                table: "appointments",
                column: "serviceId",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
