using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class FixBookRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publish_house_PublishId",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "PublishId",
                table: "books",
                newName: "Publish_houseId");

            migrationBuilder.RenameIndex(
                name: "IX_books_PublishId",
                table: "books",
                newName: "IX_books_Publish_houseId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publish_house_Publish_houseId",
                table: "books",
                column: "Publish_houseId",
                principalTable: "publish_house",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publish_house_Publish_houseId",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "Publish_houseId",
                table: "books",
                newName: "PublishId");

            migrationBuilder.RenameIndex(
                name: "IX_books_Publish_houseId",
                table: "books",
                newName: "IX_books_PublishId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publish_house_PublishId",
                table: "books",
                column: "PublishId",
                principalTable: "publish_house",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
