using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYTHUVIEN.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Chitietmuontra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chitietmuontra",
                columns: table => new
                {
                    Maphieu = table.Column<string>(type: "TEXT", nullable: false),
                    BookID = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaymuon = table.Column<string>(type: "TEXT", nullable: false),
                    ngaytra = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietmuontra", x => x.Maphieu);
                    table.ForeignKey(
                        name: "FK_Chitietmuontra_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietmuontra_Phieumuonsach_Maphieu",
                        column: x => x.Maphieu,
                        principalTable: "Phieumuonsach",
                        principalColumn: "Maphieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietmuontra_BookID",
                table: "Chitietmuontra",
                column: "BookID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietmuontra");
        }
    }
}
