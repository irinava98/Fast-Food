using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFood.Data.Migrations
{
    public partial class addProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShoppingCartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShoppingCartItems");
        }
    }
}
