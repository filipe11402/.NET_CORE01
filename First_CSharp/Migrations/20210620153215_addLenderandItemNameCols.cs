using Microsoft.EntityFrameworkCore.Migrations;

namespace First_CSharp.Migrations
{
    public partial class addLenderandItemNameCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lender",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "itemName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lender",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "itemName",
                table: "Items");
        }
    }
}
