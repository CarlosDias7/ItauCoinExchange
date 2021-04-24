using Microsoft.EntityFrameworkCore.Migrations;

namespace Itau.CoinExchange.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Discrimnator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "Discrimnator", "ExchangeRate", "Name" },
                values: new object[] { 1503778244L, "Personnalite", 0m, "Personnalite" });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "Discrimnator", "ExchangeRate", "Name" },
                values: new object[] { 1522156775L, "Private", 0m, "Private" });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "Discrimnator", "ExchangeRate", "Name" },
                values: new object[] { 1202857442L, "Varejo", 0m, "Varejo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segments");
        }
    }
}
