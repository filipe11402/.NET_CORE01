using Microsoft.EntityFrameworkCore.Migrations;

namespace First_CSharp.Migrations
{
    public partial class FixedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "ExpenseCategoryId",
                table: "Expenses",
                newName: "FKID");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                table: "Expenses",
                newName: "IX_Expenses_FKID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_FKID",
                table: "Expenses",
                column: "FKID",
                principalTable: "ExpenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_FKID",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "FKID",
                table: "Expenses",
                newName: "ExpenseCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_FKID",
                table: "Expenses",
                newName: "IX_Expenses_ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
