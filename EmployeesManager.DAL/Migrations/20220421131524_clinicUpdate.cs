using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class clinicUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadInstituteId",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "HeadClinicId",
                table: "Clinics");

            migrationBuilder.AddColumn<string>(
                name: "HeadInstitute",
                table: "Institutes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeadClinic",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadInstitute",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "HeadClinic",
                table: "Clinics");

            migrationBuilder.AddColumn<int>(
                name: "HeadInstituteId",
                table: "Institutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadClinicId",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
