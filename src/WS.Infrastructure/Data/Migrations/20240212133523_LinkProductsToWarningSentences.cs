using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LinkProductsToWarningSentences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductWarningSentences",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    WarningSentencesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarningSentences", x => new { x.ProductsId, x.WarningSentencesId });
                    table.ForeignKey(
                        name: "FK_ProductWarningSentences_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWarningSentences_WarningSentences_WarningSentencesId",
                        column: x => x.WarningSentencesId,
                        principalTable: "WarningSentences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarningSentences_WarningSentencesId",
                table: "ProductWarningSentences",
                column: "WarningSentencesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWarningSentences");
        }
    }
}
