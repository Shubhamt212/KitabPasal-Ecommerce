using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabPasall.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCartItemandDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Carts");
        }
    }
}
