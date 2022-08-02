using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class educationTypeAndParticipationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationTypeId",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipationTypeId",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EducationTypes",
                columns: table => new
                {
                    EducationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypes", x => x.EducationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ParticipationTypes",
                columns: table => new
                {
                    ParticipationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipationTypes", x => x.ParticipationTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationTypeId",
                table: "Educations",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ParticipationTypeId",
                table: "Educations",
                column: "ParticipationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_EducationTypes_EducationTypeId",
                table: "Educations",
                column: "EducationTypeId",
                principalTable: "EducationTypes",
                principalColumn: "EducationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_ParticipationTypes_ParticipationTypeId",
                table: "Educations",
                column: "ParticipationTypeId",
                principalTable: "ParticipationTypes",
                principalColumn: "ParticipationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_EducationTypes_EducationTypeId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_ParticipationTypes_ParticipationTypeId",
                table: "Educations");

            migrationBuilder.DropTable(
                name: "EducationTypes");

            migrationBuilder.DropTable(
                name: "ParticipationTypes");

            migrationBuilder.DropIndex(
                name: "IX_Educations_EducationTypeId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_ParticipationTypeId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EducationTypeId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "ParticipationTypeId",
                table: "Educations");
        }
    }
}
