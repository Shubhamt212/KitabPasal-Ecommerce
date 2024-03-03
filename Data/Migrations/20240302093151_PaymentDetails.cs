using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabPasall.Data.Migrations
{
    /// <inheritdoc />
    public partial class PaymentDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Payments");

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PaymentId",
                table: "CartItems",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Payments_PaymentId",
                table: "CartItems",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Payments_PaymentId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_PaymentId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "CartItems");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
