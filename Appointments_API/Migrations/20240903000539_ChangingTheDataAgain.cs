using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTheDataAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_services_professionals_ProfessionalId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_ProfessionalId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "appointments",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "serviceId",
                table: "appointments",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "appointments",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "appointments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_userId",
                table: "appointments",
                newName: "IX_appointments_Userid");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_serviceId",
                table: "appointments",
                newName: "IX_appointments_ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalServiceProfessionalId",
                table: "appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalServiceServiceId",
                table: "appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "professionalServices",
                columns: table => new
                {
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professionalServices", x => new { x.ProfessionalId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_professionalServices_professionals_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "professionals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professionalServices_services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_ProfessionalServiceProfessionalId_ProfessionalServiceServiceId",
                table: "appointments",
                columns: new[] { "ProfessionalServiceProfessionalId", "ProfessionalServiceServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_professionalServices_ServiceId",
                table: "professionalServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_professionalServices_ProfessionalServiceProfessionalId_ProfessionalServiceServiceId",
                table: "appointments",
                columns: new[] { "ProfessionalServiceProfessionalId", "ProfessionalServiceServiceId" },
                principalTable: "professionalServices",
                principalColumns: new[] { "ProfessionalId", "ServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_professionals_ProfessionalId",
                table: "appointments",
                column: "ProfessionalId",
                principalTable: "professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_services_ServiceId",
                table: "appointments",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_Userid",
                table: "appointments",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_professionalServices_ProfessionalServiceProfessionalId_ProfessionalServiceServiceId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_professionals_ProfessionalId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_services_ServiceId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_Userid",
                table: "appointments");

            migrationBuilder.DropTable(
                name: "professionalServices");

            migrationBuilder.DropIndex(
                name: "IX_appointments_ProfessionalServiceProfessionalId_ProfessionalServiceServiceId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "ProfessionalServiceProfessionalId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "ProfessionalServiceServiceId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "appointments",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "appointments",
                newName: "serviceId");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "appointments",
                newName: "dateTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "appointments",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_Userid",
                table: "appointments",
                newName: "IX_appointments_userId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_ServiceId",
                table: "appointments",
                newName: "IX_appointments_serviceId");

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
                name: "FK_appointments_professionals_ProfessionalId",
                table: "appointments",
                column: "ProfessionalId",
                principalTable: "professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_services_serviceId",
                table: "appointments",
                column: "serviceId",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_userId",
                table: "appointments",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
