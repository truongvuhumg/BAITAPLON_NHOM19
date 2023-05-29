using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYTHUVIEN.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Nhaxuatban : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhaxuatban",
                columns: table => new
                {
                    NXBID = table.Column<string>(type: "TEXT", nullable: false),
                    NXBName = table.Column<string>(type: "TEXT", nullable: false),
                    NXBAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhaxuatban", x => x.NXBID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhaxuatban");
        }
    }
}
