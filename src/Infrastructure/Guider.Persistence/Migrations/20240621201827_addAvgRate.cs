using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addAvgRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AverageRate",
                table: "Consultants",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRate",
                table: "Consultants");
        }
    }
}
