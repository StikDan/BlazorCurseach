using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCurseach.Migrations
{
    /// <inheritdoc />
    public partial class TotalSumOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalSum",
                table: "Order");
        }
    }
}
