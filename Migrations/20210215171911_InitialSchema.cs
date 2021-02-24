using Microsoft.EntityFrameworkCore.Migrations;

namespace Orphanage.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    donate_type = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    message = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");
        }
    }
}
