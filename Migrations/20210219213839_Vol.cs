using Microsoft.EntityFrameworkCore.Migrations;

namespace Orphanage.Migrations
{
    public partial class Vol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: false),
                    event_name = table.Column<string>(nullable: false),
                    event_date = table.Column<string>(nullable: false),
                    time = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteers");
        }
    }
}
