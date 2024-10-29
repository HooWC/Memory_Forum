using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructur.Migrations
{
    public partial class add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Halls",
                table: "Halls");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "PostWords");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "MessageCalls");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Halls",
                newName: "Friends");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostWords",
                table: "PostWords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCalls",
                table: "MessageCalls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostWords",
                table: "PostWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCalls",
                table: "MessageCalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "PostWords",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "MessageCalls",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Halls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Halls",
                table: "Halls",
                column: "Id");
        }
    }
}
