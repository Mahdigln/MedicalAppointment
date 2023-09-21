using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Fixtiming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Appointments_AppointmentAppoimtmentId",
                table: "Timings");

            migrationBuilder.DropIndex(
                name: "IX_Timings_AppointmentAppoimtmentId",
                table: "Timings");

            migrationBuilder.DropColumn(
                name: "AppointmentAppoimtmentId",
                table: "Timings");

            migrationBuilder.RenameColumn(
                name: "AppoimtmentId",
                table: "Timings",
                newName: "AppointmentId");

            migrationBuilder.RenameColumn(
                name: "AppoimtmentId",
                table: "Appointments",
                newName: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_AppointmentId",
                table: "Timings",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Appointments_AppointmentId",
                table: "Timings",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Appointments_AppointmentId",
                table: "Timings");

            migrationBuilder.DropIndex(
                name: "IX_Timings_AppointmentId",
                table: "Timings");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Timings",
                newName: "AppoimtmentId");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Appointments",
                newName: "AppoimtmentId");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentAppoimtmentId",
                table: "Timings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timings_AppointmentAppoimtmentId",
                table: "Timings",
                column: "AppointmentAppoimtmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Appointments_AppointmentAppoimtmentId",
                table: "Timings",
                column: "AppointmentAppoimtmentId",
                principalTable: "Appointments",
                principalColumn: "AppoimtmentId");
        }
    }
}
