using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPictogramText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "WarningPictograms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "WarningPictograms");
        }
    }
}
