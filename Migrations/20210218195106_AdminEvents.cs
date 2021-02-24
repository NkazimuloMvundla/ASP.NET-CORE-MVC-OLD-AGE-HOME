using Microsoft.EntityFrameworkCore.Migrations;

namespace Orphanage.Migrations
{
    public partial class AdminEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Admins",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Admins",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Admins");
        }
    }
}
