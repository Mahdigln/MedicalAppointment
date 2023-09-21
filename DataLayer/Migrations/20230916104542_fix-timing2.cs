using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixtiming2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Appointments_AppointmentId",
                table: "Timings");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Timings",
                newName: "AppointmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Timings_AppointmentId",
                table: "Timings",
                newName: "IX_Timings_AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Appointments_AppointmentID",
                table: "Timings",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Appointments_AppointmentID",
                table: "Timings");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "Timings",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Timings_AppointmentID",
                table: "Timings",
                newName: "IX_Timings_AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Appointments_AppointmentId",
                table: "Timings",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
