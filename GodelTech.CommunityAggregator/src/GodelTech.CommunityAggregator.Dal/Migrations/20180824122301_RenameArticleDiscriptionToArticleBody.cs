using Microsoft.EntityFrameworkCore.Migrations;

namespace GodelTech.CommunityAggregator.Dal.Migrations
{
    public partial class RenameArticleDiscriptionToArticleBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Articles",
                newName: "Body");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Articles",
                newName: "Description");
        }
    }
}
