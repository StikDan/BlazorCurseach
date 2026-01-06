using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCurseach.Migrations
{
    /// <inheritdoc />
    public partial class AddedValuesCharacteristics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ValueCharacteristic_idCharacteristicItem",
                table: "ValueCharacteristic",
                column: "idCharacteristicItem");

            migrationBuilder.AddForeignKey(
                name: "fk_CharacteristicItem_Category1_idx",
                table: "CharacteristicItem",
                column: "idCategory",
                principalTable: "Category",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValueCharacteristic");

            migrationBuilder.DropIndex(
                name: "fk_CharacteristicItem_Category1_idx",
                table: "CharacteristicItem");

            migrationBuilder.DropColumn(
                name: "idCategory",
                table: "CharacteristicItem");
        }
    }
}
