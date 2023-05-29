using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYTHUVIEN.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Phieumuonsach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phieumuonsach",
                columns: table => new
                {
                    Maphieu = table.Column<string>(type: "TEXT", nullable: false),
                    ReaderName = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieumuonsach", x => x.Maphieu);
                    table.ForeignKey(
                        name: "FK_Phieumuonsach_Employee_EmployeeName",
                        column: x => x.EmployeeName,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phieumuonsach_Readers_ReaderName",
                        column: x => x.ReaderName,
                        principalTable: "Readers",
                        principalColumn: "ReaderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonsach_EmployeeName",
                table: "Phieumuonsach",
                column: "EmployeeName");

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonsach_ReaderName",
                table: "Phieumuonsach",
                column: "ReaderName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phieumuonsach");
        }
    }
}
