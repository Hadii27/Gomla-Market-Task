using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GomlaMarket.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQTYtoINT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NetQuantitySold",
                table: "saleRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "NetPurchaseQuantity",
                table: "purchaseRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NetQuantitySold",
                table: "saleRecords",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "NetPurchaseQuantity",
                table: "purchaseRecords",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
