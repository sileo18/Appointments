using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class TryingFixTheError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_UserId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_services_professionals_ProfessionalId",
                table: "services");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_UserId",
                table: "appointments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_professionals_ProfessionalId",
                table: "services",
                column: "ProfessionalId",
                principalTable: "professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_UserId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_services_professionals_ProfessionalId",
                table: "services");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_UserId",
                table: "appointments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_services_professionals_ProfessionalId",
                table: "services",
                column: "ProfessionalId",
                principalTable: "professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
