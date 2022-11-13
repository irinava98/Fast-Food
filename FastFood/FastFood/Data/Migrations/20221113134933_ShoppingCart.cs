using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Data.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCardId",
                table: "ShoppingCartItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCardId",
                table: "ShoppingCartItems",
                column: "ShoppingCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCart_ShoppingCardId",
                table: "ShoppingCartItems",
                column: "ShoppingCardId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCart_ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCardId",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
