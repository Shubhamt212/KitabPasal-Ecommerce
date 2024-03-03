using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabPasall.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCartModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Imagepath",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Carts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagepath",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
