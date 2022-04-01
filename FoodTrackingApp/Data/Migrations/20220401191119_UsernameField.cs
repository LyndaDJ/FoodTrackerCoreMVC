using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackingApp.Data.Migrations
{
    public partial class UsernameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserProfile");
        }
    }
}
