using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructur.Migrations
{
    public partial class add8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Friends",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Friends");
        }
    }
}
