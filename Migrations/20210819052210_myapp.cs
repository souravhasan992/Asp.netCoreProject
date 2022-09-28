using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvedinceFinal.Migrations
{
    public partial class myapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "designation",
                columns: table => new
                {
                    Designation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designation", x => x.Designation_ID);
                });

            migrationBuilder.CreateTable(
                name: "employeeRegistrations",
                columns: table => new
                {
                    Reg_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reg_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeRegistrations", x => x.Reg_ID);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Shift_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShortCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Onetime = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    OvertimeStart = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    OvertimeEnd = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ShiftType = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Shift_ID);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Marital_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Joining_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Designation_ID = table.Column<int>(type: "int", nullable: true),
                    Designation_ID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "FK_employee_designation_Designation_ID1",
                        column: x => x.Designation_ID1,
                        principalTable: "designation",
                        principalColumn: "Designation_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_Designation_ID1",
                table: "employee",
                column: "Designation_ID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "employeeRegistrations");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "designation");
        }
    }
}
