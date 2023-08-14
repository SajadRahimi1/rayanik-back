using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rayanik_back.Migrations
{
    public partial class CourseImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "weekNumber",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "weeksCount",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "weekNumber",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "weeksCount",
                table: "Courses");
        }
    }
}
