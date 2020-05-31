using Microsoft.EntityFrameworkCore.Migrations;

namespace TechData.Migrations
{
    public partial class ExtendIdentityUserAddedBranchName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeBranch",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeBranch",
                table: "AspNetUsers");
        }
    }
}
