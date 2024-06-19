using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deletAdminfromTrasatin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Admins_AdminId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Admins_AdminId",
                table: "Transactions",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Admins_AdminId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Admins_AdminId",
                table: "Transactions",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }
    }
}
