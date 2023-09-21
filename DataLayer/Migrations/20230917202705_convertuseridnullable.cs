using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class convertuseridnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Users_UserId",
                table: "Timings");

            migrationBuilder.DropIndex(
                name: "IX_Timings_UserId",
                table: "Timings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Timings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_UserId",
                table: "Timings",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Users_UserId",
                table: "Timings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_Users_UserId",
                table: "Timings");

            migrationBuilder.DropIndex(
                name: "IX_Timings_UserId",
                table: "Timings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Timings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timings_UserId",
                table: "Timings",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_Users_UserId",
                table: "Timings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
