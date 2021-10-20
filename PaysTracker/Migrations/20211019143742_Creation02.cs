using Microsoft.EntityFrameworkCore.Migrations;

namespace PaysTracker.Migrations
{
    public partial class Creation02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Index",
                table: "ListeRegimes",
                newName: "RegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListePays_RegimeId",
                table: "ListePays",
                column: "RegimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListePays_ListeRegimes_RegimeId",
                table: "ListePays",
                column: "RegimeId",
                principalTable: "ListeRegimes",
                principalColumn: "RegimeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListePays_ListeRegimes_RegimeId",
                table: "ListePays");

            migrationBuilder.DropIndex(
                name: "IX_ListePays_RegimeId",
                table: "ListePays");

            migrationBuilder.RenameColumn(
                name: "RegimeId",
                table: "ListeRegimes",
                newName: "Index");
        }
    }
}
