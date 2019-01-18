using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsDishes.Migrations
{
    public partial class DishModelDescriptionColumnMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dishes",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dishes");
        }
    }
}
