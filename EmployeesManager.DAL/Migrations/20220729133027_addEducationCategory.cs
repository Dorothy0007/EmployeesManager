using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class addEducationCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Institutes_InstituteId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutes_Clinics_ClinicId",
                table: "Institutes");

            migrationBuilder.DropForeignKey(
                name: "FK_Workplaces_Departments_DepartmentId",
                table: "Workplaces");

            migrationBuilder.DropColumn(
                name: "EducationCategory",
                table: "Educations");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Workplaces",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Institutes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InstituteId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "EducationCategories",
                columns: table => new
                {
                    EducationCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCategories", x => x.EducationCategoryId);
                    table.ForeignKey(
                        name: "FK_EducationCategories_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "EducationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationCategories_EducationId",
                table: "EducationCategories",
                column: "EducationId",
                unique: true,
                filter: "[EducationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Institutes_InstituteId",
                table: "Departments",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutes_Clinics_ClinicId",
                table: "Institutes",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workplaces_Departments_DepartmentId",
                table: "Workplaces",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Institutes_InstituteId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutes_Clinics_ClinicId",
                table: "Institutes");

            migrationBuilder.DropForeignKey(
                name: "FK_Workplaces_Departments_DepartmentId",
                table: "Workplaces");

            migrationBuilder.DropTable(
                name: "EducationCategories");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Workplaces",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Institutes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationCategory",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "InstituteId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Institutes_InstituteId",
                table: "Departments",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "InstituteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutes_Clinics_ClinicId",
                table: "Institutes",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workplaces_Departments_DepartmentId",
                table: "Workplaces",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
