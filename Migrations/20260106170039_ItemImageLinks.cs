using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCurseach.Migrations
{
    /// <inheritdoc />
    public partial class ItemImageLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageLink",
                table: "Item");
        }
    }
}
