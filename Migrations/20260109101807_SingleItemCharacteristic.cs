using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCurseach.Migrations
{
    /// <inheritdoc />
    public partial class SingleItemCharacteristic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imageLink",
                table: "Item",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Ссылка на изображение товара в приложении",
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldComment: "Ссылка на изображение товара в приложении")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCharacteristicValue");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "imageLink",
                keyValue: null,
                column: "imageLink",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "imageLink",
                table: "Item",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Ссылка на изображение товара в приложении",
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Ссылка на изображение товара в приложении")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");
        }
    }
}
