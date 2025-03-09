using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Discussion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_AppUserId",
                table: "Discussion",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AppUserId",
                table: "Comment",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_AppUserId",
                table: "Comment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussion_AspNetUsers_AppUserId",
                table: "Discussion",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_AppUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_AppUserId",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Discussion_AppUserId",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AppUserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Discussion");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comment");
        }
    }
}
