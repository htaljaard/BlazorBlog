using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBlog.UI.data.migrations
{
    /// <inheritdoc />
    public partial class BlogImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogImageUrl",
                table: "blogs",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogImageUrl",
                table: "blogs");
        }
    }
}
