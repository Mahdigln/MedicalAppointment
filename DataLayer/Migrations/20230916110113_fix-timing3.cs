using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixtiming3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Appointments_AppointmentID",
                table: "Timings");

            migrationBuilder.DropIndex(
                name: "IX_Timings_AppointmentID",
                table: "Timings");

            migrationBuilder.DropColumn(
                name: "AppointmentID",
                table: "Timings");

            migrationBuilder.AddColumn<int>(
                name: "TimingId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimingId",
                table: "Appointments",
                column: "TimingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Timings_TimingId",
                table: "Appointments",
                column: "TimingId",
                principalTable: "Timings",
                principalColumn: "TimingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Timings_TimingId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimingId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TimingId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentID",
                table: "Timings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Timings_AppointmentID",
                table: "Timings",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Appointments_AppointmentID",
                table: "Timings",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
