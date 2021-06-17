using Microsoft.EntityFrameworkCore.Migrations;

namespace SundownBoulevard.Core.Migrations
{
    public partial class AddChosenMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChosenBeerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChosenMenuId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenBeerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ChosenMenuId",
                table: "Orders");
        }
    }
}
