using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyProfessionalInServicesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professionals_services_ServiceId",
                table: "professionals");

            migrationBuilder.DropIndex(
                name: "IX_professionals_ServiceId",
                table: "professionals");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "professionals");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId",
                table: "services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_services_ProfessionalId",
                table: "services",
                column: "ProfessionalId");

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
                name: "FK_services_professionals_ProfessionalId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_ProfessionalId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "services");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "professionals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_professionals_ServiceId",
                table: "professionals",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_professionals_services_ServiceId",
                table: "professionals",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
