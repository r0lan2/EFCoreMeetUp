using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.vDimensions
            AS

                SELECT 
            b.BlogId,
            COUNT(*) AS NumberOfPosts

            FROM Blogs b join Posts p 
            ON B.BlogId= P.BlogId
            GROUP BY b.BlogId

                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.vDimensions");
        }
    }
}
