using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class HealthcareChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Healthcares");

            migrationBuilder.AddColumn<int>(
                name: "HealthcareName",
                table: "Healthcares",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthcareName",
                table: "Healthcares");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Healthcares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
