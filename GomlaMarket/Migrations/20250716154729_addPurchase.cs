using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GomlaMarket.Migrations
{
    /// <inheritdoc />
    public partial class addPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "purchaseRecords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetPurchasesValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseReturnRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonusQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPurchaseQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseRecords", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseRecords");
        }
    }
}
