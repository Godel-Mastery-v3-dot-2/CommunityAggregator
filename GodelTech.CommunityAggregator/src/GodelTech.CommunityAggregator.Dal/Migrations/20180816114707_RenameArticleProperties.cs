using Microsoft.EntityFrameworkCore.Migrations;

namespace GodelTech.CommunityAggregator.Dal.Migrations
{
    public partial class RenameArticleProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Articles",
                newName: "PublishDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Articles",
                newName: "Date");
        }
    }
}
