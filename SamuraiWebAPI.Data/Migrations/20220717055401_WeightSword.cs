using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiWebAPI.Data.Migrations
{
    public partial class WeightSword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Swords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Swords");
        }
    }
}
