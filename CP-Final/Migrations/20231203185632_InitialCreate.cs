using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP_Final.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flavor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForkSpoonHands = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    SeasonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weather = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Holidays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSeasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    HobbyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursPerWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartedHobby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.MemberID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteFoods");

            migrationBuilder.DropTable(
                name: "FavoriteSeasons");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
