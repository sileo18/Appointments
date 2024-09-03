using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentsForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "professionalId",
                table: "appointments",
                newName: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_ProfessionalId",
                table: "appointments",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_serviceId",
                table: "appointments",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_userId",
                table: "appointments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_professionals_ProfessionalId",
                table: "appointments",
                column: "ProfessionalId",
                principalTable: "professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_services_serviceId",
                table: "appointments",
                column: "serviceId",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_userId",
                table: "appointments",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_professionals_ProfessionalId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_services_serviceId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_userId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_ProfessionalId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_serviceId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_userId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "appointments",
                newName: "professionalId");
        }
    }
}
