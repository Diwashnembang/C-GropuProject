using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class addednewmenutype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuType",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuType",
                table: "MenuItems");
        }
    }
}
