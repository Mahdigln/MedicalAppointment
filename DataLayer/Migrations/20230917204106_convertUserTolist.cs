using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class convertUserTolist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Timings_UserId",
                table: "Timings");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_UserId",
                table: "Timings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Timings_UserId",
                table: "Timings");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_UserId",
                table: "Timings",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
