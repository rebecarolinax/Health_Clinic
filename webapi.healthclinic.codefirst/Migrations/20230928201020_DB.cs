using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.healthclinic.codefirst.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeMedico",
                table: "Medico",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeMedico",
                table: "Medico",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");
        }
    }
}
