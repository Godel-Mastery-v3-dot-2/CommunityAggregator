using Microsoft.EntityFrameworkCore.Migrations;

namespace GodelTech.CommunityAggregator.Dal.Migrations
{
    public partial class ChangeRoleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");
        }
    }
}
