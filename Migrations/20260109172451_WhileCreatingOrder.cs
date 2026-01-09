using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCurseach.Migrations
{
    /// <inheritdoc />
    public partial class WhileCreatingOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "OrderItemTemp");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "ItemCharacteristicValue");

            migrationBuilder.DropColumn(
                name: "idOrderItemTemp",
                table: "OrderItemTemp");

            migrationBuilder.DropColumn(
                name: "idItemCharacteristicValue",
                table: "ItemCharacteristicValue");
        }
    }
}
