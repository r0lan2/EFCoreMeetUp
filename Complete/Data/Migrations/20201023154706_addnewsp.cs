using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addnewsp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.GetBlogStats   
                                AS

                                BEGIN

                                SELECT 	
	                                B.Url AS BlogName,
	                                COUNT(*) AS NumberOfPosts
                                FROM Blogs b join Posts p 
                                ON B.BlogId= P.BlogId
                                GROUP BY b.Url	

                                END
                                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetBlogStats");
        }
    }
}
