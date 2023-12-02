using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP_Final.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

------


using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupAPIFinal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavoriteFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flavor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForkSpoonHands = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hobby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursPerWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartedHobby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavoriteSeason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Holidays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberInfos",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "MemberID", "FavoriteFood", "FoodCategory", "Flavor", "ForkSpoonHands" },
                values: new object[,]
                {
                    { 1, "Pasta", "Italian", "Spicy", "Fork" },
                    { 2, "BBQ", "Korean", "Mild", "Fork" },
                    { 3, "Steak", "American", "Mild", "Fork" }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "MemberID", "Hobby", "HoursPerWeek", "StartedHobby", "Description" },
                values: new object[,]
                {
                    { 1, "Painting", "forty", "Photography", "I spend a lot of time painting" },
                    { 2, "Video Games", "twenty", "Hiking", "I play video games after work" },
                    { 3, "Golfing ", "fifteen", "Traveling", "I like golfing with my friends" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "MemberID", "FavoriteSeason", "Weather", "Holidays", "Reason" },
                values: new object[,]
                {
                    { 1, "Winter", "Cold", "Christmas", "I like to play in snow" },
                    { 2, "Summer", "Warm", "Summer Break", "I like being able to wear shorts and go outside" },
                    { 3, "Fall", "Warm", "Christmas", "I like Christmas holidays for the presents but I like fall season" }
                });

            migrationBuilder.InsertData(
                table: "MemberInfos",
                columns: new[] { "MemberID", "Birthdate", "Program", "MemberName", "MemberYear" },
                values: new object[,]
                {
                    { 1, "June 3rd 2003", "Information Technology", "Travis Scott", 2025 },
                    { 2, "January 12th 2002", "Information Technology", "Jacob Khan", 2025 },
                    { 3, "January 22nd 2003", "Information Technology", "Joji Alexander", 2025 }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "MemberInfos");

        }
    }
}

