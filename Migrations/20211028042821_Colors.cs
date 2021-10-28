using Microsoft.EntityFrameworkCore.Migrations;

namespace roadlovers.Migrations
{
    public partial class Colors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Vehicle_Color",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Vehicle_Color", x => new { x.CarId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_Tbl_Vehicle_Color_Tbl_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Tbl_Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Vehicle_Color_Tbl_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Tbl_Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Vehicle_Color_ColorId",
                table: "Tbl_Vehicle_Color",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Vehicle_Color");

            migrationBuilder.DropTable(
                name: "Tbl_Color");
        }
    }
}
