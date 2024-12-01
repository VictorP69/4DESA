using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace social_media.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMediaFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Posts_PostId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_PostId",
                table: "Media");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Media_PostId",
                table: "Media",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Posts_PostId",
                table: "Media",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
