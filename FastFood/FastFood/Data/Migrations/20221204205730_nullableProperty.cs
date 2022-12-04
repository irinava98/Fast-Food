using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Data.Migrations
{
    public partial class nullableProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Foods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
