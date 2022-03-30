using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesManager.DAL.Migrations
{
    public partial class removeAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "BusinessEmail",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessMobilePhone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessTelephone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrivateEmail",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrivateMobilePhone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "BusinessEmail",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BusinessMobilePhone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BusinessTelephone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PrivateEmail",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PrivateMobilePhone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeId",
                table: "Addresses",
                column: "EmployeeId",
                unique: true);
        }
    }
}
