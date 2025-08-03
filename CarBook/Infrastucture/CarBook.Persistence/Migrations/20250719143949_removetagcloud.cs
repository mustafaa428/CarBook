using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removetagcloud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagClouds_Blogs_BlogId",
                table: "TagClouds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagClouds",
                table: "TagClouds");

            migrationBuilder.RenameTable(
                name: "TagClouds",
                newName: "TagCloud");

            migrationBuilder.RenameIndex(
                name: "IX_TagClouds_BlogId",
                table: "TagCloud",
                newName: "IX_TagCloud_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagCloud",
                table: "TagCloud",
                column: "TagCloudId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagCloud_Blogs_BlogId",
                table: "TagCloud",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCloud_Blogs_BlogId",
                table: "TagCloud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagCloud",
                table: "TagCloud");

            migrationBuilder.RenameTable(
                name: "TagCloud",
                newName: "TagClouds");

            migrationBuilder.RenameIndex(
                name: "IX_TagCloud_BlogId",
                table: "TagClouds",
                newName: "IX_TagClouds_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagClouds",
                table: "TagClouds",
                column: "TagCloudId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagClouds_Blogs_BlogId",
                table: "TagClouds",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
