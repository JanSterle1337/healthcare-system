using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthcare_system.Migrations
{
    /// <inheritdoc />
    public partial class medicineModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "medicines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "medicines");
        }
    }
}
