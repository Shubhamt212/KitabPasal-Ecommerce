using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabPasall.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCartData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagepath",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Imagepath",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CartItems");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
