using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructur.Migrations
{
    public partial class add6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Comment",
                table: "PostWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "PostWords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "PostWords");

            migrationBuilder.DropColumn(
                name: "View",
                table: "PostWords");
        }
    }
}
