using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreConsole.Migrations
{
    public partial class addauthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Blogs",
                nullable: true);


           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Blogs");
        }
    }
}
