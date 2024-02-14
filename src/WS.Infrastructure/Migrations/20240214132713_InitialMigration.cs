using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ProducerAddress",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarningPictograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pictogram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarningPictograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarningSignalWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignalWordText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarningSignalWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarningTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarningTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producers_ProducerAddress_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "ProducerAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarningCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarningTypeId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarningCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarningCategories_WarningTypes_WarningTypeId",
                        column: x => x.WarningTypeId,
                        principalTable: "WarningTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_Id",
                        column: x => x.Id,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatus_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarningSentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarningCategoryId = table.Column<int>(type: "int", nullable: false),
                    WarningPictogramId = table.Column<int>(type: "int", nullable: false),
                    WarningSignalWordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarningSentences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarningSentences_WarningCategories_WarningCategoryId",
                        column: x => x.WarningCategoryId,
                        principalTable: "WarningCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarningSentences_WarningPictograms_WarningPictogramId",
                        column: x => x.WarningPictogramId,
                        principalTable: "WarningPictograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarningSentences_WarningSignalWords_WarningSignalWordId",
                        column: x => x.WarningSignalWordId,
                        principalTable: "WarningSignalWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Producers_AddressId",
                table: "Producers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductGroupId",
                table: "ProductCategories",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarningSentences_WarningSentencesId",
                table: "ProductWarningSentences",
                column: "WarningSentencesId");

            migrationBuilder.CreateIndex(
                name: "IX_WarningCategories_WarningTypeId",
                table: "WarningCategories",
                column: "WarningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WarningSentences_WarningCategoryId",
                table: "WarningSentences",
                column: "WarningCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WarningSentences_WarningPictogramId",
                table: "WarningSentences",
                column: "WarningPictogramId");

            migrationBuilder.CreateIndex(
                name: "IX_WarningSentences_WarningSignalWordId",
                table: "WarningSentences",
                column: "WarningSignalWordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWarningSentences");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WarningSentences");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductStatus");

            migrationBuilder.DropTable(
                name: "WarningCategories");

            migrationBuilder.DropTable(
                name: "WarningPictograms");

            migrationBuilder.DropTable(
                name: "WarningSignalWords");

            migrationBuilder.DropTable(
                name: "ProducerAddress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "WarningTypes");
        }
    }
}
