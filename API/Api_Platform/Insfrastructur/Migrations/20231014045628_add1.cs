using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructur.Migrations
{
    public partial class add1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    friendid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    friendid = table.Column<int>(type: "int", nullable: false),
                    word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    otherid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imglist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    type_main = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_post = table.Column<DateTime>(type: "datetime2", nullable: false),
                    money = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userNoId = table.Column<int>(type: "int", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experience = table.Column<int>(type: "int", nullable: false),
                    maxexperience = table.Column<int>(type: "int", nullable: false),
                    signIn = table.Column<bool>(type: "bit", nullable: false),
                    signInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    continuous_check_day = table.Column<int>(type: "int", nullable: false),
                    total_day = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    security_question = table.Column<int>(type: "int", nullable: false),
                    security_question_answers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
