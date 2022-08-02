using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class EducationCategoryChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationCategories_Educations_EducationId",
                table: "EducationCategories");

            migrationBuilder.DropIndex(
                name: "IX_EducationCategories_EducationId",
                table: "EducationCategories");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "EducationCategories");

            migrationBuilder.AddColumn<int>(
                name: "EducationCategoryId",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationCategoryId",
                table: "Educations",
                column: "EducationCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_EducationCategories_EducationCategoryId",
                table: "Educations",
                column: "EducationCategoryId",
                principalTable: "EducationCategories",
                principalColumn: "EducationCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_EducationCategories_EducationCategoryId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_EducationCategoryId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EducationCategoryId",
                table: "Educations");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "EducationCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EducationCategories_EducationId",
                table: "EducationCategories",
                column: "EducationId",
                unique: true,
                filter: "[EducationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationCategories_Educations_EducationId",
                table: "EducationCategories",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "EducationId");
        }
    }
}
