using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructur.Migrations
{
    public partial class add5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "login_count",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "login_count",
                table: "Users");
        }
    }
}
