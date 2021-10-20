using Microsoft.EntityFrameworkCore.Migrations;

namespace PaysTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListePays",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegimeId = table.Column<int>(type: "int", nullable: false),
                    Dirigeant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surface = table.Column<int>(type: "int", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListePays", x => x.Nom);
                });

            migrationBuilder.CreateTable(
                name: "ListeRegimes",
                columns: table => new
                {
                    Index = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeRegimes", x => x.Index);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListePays");

            migrationBuilder.DropTable(
                name: "ListeRegimes");
        }
    }
}
