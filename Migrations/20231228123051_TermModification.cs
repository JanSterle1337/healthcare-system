using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthcare_system.Migrations
{
    /// <inheritdoc />
    public partial class TermModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TermReservations_TermReservations_termReservationReservationId",
                table: "TermReservations");

            migrationBuilder.DropIndex(
                name: "IX_TermReservations_termReservationReservationId",
                table: "TermReservations");

            migrationBuilder.DropColumn(
                name: "termReservationReservationId",
                table: "TermReservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "termReservationReservationId",
                table: "TermReservations",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TermReservations_termReservationReservationId",
                table: "TermReservations",
                column: "termReservationReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TermReservations_TermReservations_termReservationReservationId",
                table: "TermReservations",
                column: "termReservationReservationId",
                principalTable: "TermReservations",
                principalColumn: "ReservationId");
        }
    }
}
