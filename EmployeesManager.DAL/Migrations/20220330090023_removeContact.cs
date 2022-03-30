using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class removeContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessMobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateMobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts",
                column: "EmployeeId");
        }
    }
}
