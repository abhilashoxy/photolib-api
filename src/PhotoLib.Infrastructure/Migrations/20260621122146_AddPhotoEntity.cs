using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoLib.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTaken",
                table: "Photos",
                newName: "UploadedAt");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Photos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSizeBytes",
                table: "Photos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "Photos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoragePath",
                table: "Photos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "FileSizeBytes",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "StoragePath",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "Photos",
                newName: "DateTaken");
        }
    }
}
