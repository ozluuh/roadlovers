using Microsoft.EntityFrameworkCore.Migrations;

namespace roadlovers.Migrations
{
    public partial class UpdateStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Classes_VehicleTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "Tbl_Manufacturers");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Tbl_Classes");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Tbl_Cars");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Tbl_Manufacturers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "Tbl_Classes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Tbl_Cars",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Tbl_Cars",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_VehicleTypeId",
                table: "Tbl_Cars",
                newName: "IX_Tbl_Cars_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Tbl_Cars",
                newName: "IX_Tbl_Cars_ManufacturerId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Tbl_Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Tbl_Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Manufacturers",
                table: "Tbl_Manufacturers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Classes",
                table: "Tbl_Classes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Cars",
                table: "Tbl_Cars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Cars_Tbl_Classes_VehicleTypeId",
                table: "Tbl_Cars",
                column: "VehicleTypeId",
                principalTable: "Tbl_Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Cars_Tbl_Manufacturers_ManufacturerId",
                table: "Tbl_Cars",
                column: "ManufacturerId",
                principalTable: "Tbl_Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cars_Tbl_Classes_VehicleTypeId",
                table: "Tbl_Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cars_Tbl_Manufacturers_ManufacturerId",
                table: "Tbl_Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Manufacturers",
                table: "Tbl_Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Classes",
                table: "Tbl_Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Cars",
                table: "Tbl_Cars");

            migrationBuilder.RenameTable(
                name: "Tbl_Manufacturers",
                newName: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "Tbl_Classes",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "Tbl_Cars",
                newName: "Cars");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Manufacturers",
                newName: "ManufacturerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Classes",
                newName: "VehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Cars",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Cars_VehicleTypeId",
                table: "Cars",
                newName: "IX_Cars_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Cars_ManufacturerId",
                table: "Cars",
                newName: "IX_Cars_ManufacturerId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "VehicleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Classes_VehicleTypeId",
                table: "Cars",
                column: "VehicleTypeId",
                principalTable: "Classes",
                principalColumn: "VehicleTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
