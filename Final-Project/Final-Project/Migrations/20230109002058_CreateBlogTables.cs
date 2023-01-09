using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations
{
    public partial class CreateBlogTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
