using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthcare_system.Migrations
{
    /// <inheritdoc />
    public partial class TermModification4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TermStatus",
                table: "TermReservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "neizvedeno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermStatus",
                table: "TermReservations");
        }
    }
}
