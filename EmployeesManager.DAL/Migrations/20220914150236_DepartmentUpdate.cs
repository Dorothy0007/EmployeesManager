using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class DepartmentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadDepartmentId",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "HeadDepartmentName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadDepartmentName",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
