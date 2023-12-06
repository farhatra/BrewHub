using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewHub.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.BreweryId);
                });

            migrationBuilder.CreateTable(
                name: "Wholesalers",
                columns: table => new
                {
                    WholesalerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.WholesalerId);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "BreweryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WholesalerId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quotes_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WholesalerBeers",
                columns: table => new
                {
                    WholesalerId = table.Column<int>(type: "int", nullable: false),
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    RemainingQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholesalerBeers", x => new { x.WholesalerId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_WholesalerBeers_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WholesalerBeers_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteDetails",
                columns: table => new
                {
                    QuoteDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteDetails", x => x.QuoteDetailId);
                    table.ForeignKey(
                        name: "FK_QuoteDetails_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuoteDetails_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "BreweryId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Chimay, Belgium", "Chimay Brewery" },
                    { 2, "Westmalle, Belgium", "Westmalle Brewery" },
                    { 3, "Rochefort, Belgium", "Rochefort Brewery" },
                    { 4, "Puurs, Belgium", "Duvel Moortgat Brewery" },
                    { 5, "Achouffe, Belgium", "Achouffe Brewery" },
                    { 6, "Watou, Belgium", "St. Bernardus Brewery" },
                    { 7, "Brussels, Belgium", "Brasserie de la Senne" }
                });

            migrationBuilder.InsertData(
                table: "Wholesalers",
                columns: new[] { "WholesalerId", "Name", "Stock" },
                values: new object[,]
                {
                    { 1, "Belgian Beer Distributors", 100 },
                    { 2, "Brewery Warehouse", 150 },
                    { 3, "Global Beverages", 120 },
                    { 4, "Hop Haven", 80 },
                    { 5, "Bier Bazaar", 200 },
                    { 6, "Beer Paradise", 170 },
                    { 7, "Eurobrew Imports", 130 }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "BeerId", "BreweryId", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Chimay Blue", 10.0m, "Trappist Ale" },
                    { 2, 1, "Chimay Red", 8.0m, "Dubbel" },
                    { 3, 2, "Westmalle Tripel", 9.0m, "Tripel" },
                    { 4, 3, "Rochefort 10", 12.0m, "Quadrupel" },
                    { 5, 4, "Duvel", 11.0m, "Strong Pale Ale" },
                    { 6, 5, "La Chouffe", 10.5m, "Belgian Strong Ale" },
                    { 7, 6, "St. Bernardus Abt 12", 11.5m, "Quadrupel" },
                    { 8, 7, "Brusseleir", 9.5m, "Belgian Pale Ale" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "ClientId", "Summary", "TotalPrice", "WholesalerId" },
                values: new object[,]
                {
                    { 1, "Client1", "Quote summary 1", 200.0m, 1 },
                    { 2, "Client2", "Quote summary 2", 150.0m, 2 },
                    { 3, "Client3", "Quote summary 3", 180.0m, 3 }
                });

            migrationBuilder.InsertData(
                table: "QuoteDetails",
                columns: new[] { "QuoteDetailId", "BeerId", "Discount", "Quantity", "QuoteId" },
                values: new object[,]
                {
                    { 1, 1, 0.0m, 10, 1 },
                    { 2, 2, 5.0m, 15, 1 },
                    { 3, 3, 10.0m, 20, 2 },
                    { 4, 4, 2.0m, 8, 3 },
                    { 5, 5, 4.0m, 12, 3 }
                });

            migrationBuilder.InsertData(
                table: "WholesalerBeers",
                columns: new[] { "BeerId", "WholesalerId", "RemainingQuantity" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 2, 1, 75 },
                    { 3, 2, 100 },
                    { 4, 3, 60 },
                    { 5, 3, 90 },
                    { 6, 4, 110 },
                    { 7, 5, 80 },
                    { 8, 6, 120 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteDetails_BeerId",
                table: "QuoteDetails",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteDetails_QuoteId",
                table: "QuoteDetails",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_WholesalerId",
                table: "Quotes",
                column: "WholesalerId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesalerBeers_BeerId",
                table: "WholesalerBeers",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteDetails");

            migrationBuilder.DropTable(
                name: "WholesalerBeers");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Wholesalers");

            migrationBuilder.DropTable(
                name: "Breweries");
        }
    }
}
