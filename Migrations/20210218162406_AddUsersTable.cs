using Microsoft.EntityFrameworkCore.Migrations;

namespace Orphanage.Migrations
{
    public partial class AddUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    ConfirmPassword = table.Column<string>(maxLength: 255, nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
