using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GomlaMarket.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "saleRecords",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainGroupCode = table.Column<int>(type: "int", nullable: false),
                    MainGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubGroupCode = table.Column<int>(type: "int", nullable: false),
                    SubGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetQuantitySold = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalesValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleRecords", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saleRecords");
        }
    }
}
