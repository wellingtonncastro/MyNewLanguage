using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNewLanguage.Migrations
{
    public partial class AddUserInDeck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Decks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Decks");
        }
    }
}
