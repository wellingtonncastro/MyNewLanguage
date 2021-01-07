using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNewLanguage.Migrations
{
    public partial class tokeninuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JsonWebToken",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JsonWebToken",
                table: "AspNetUsers");
        }
    }
}
