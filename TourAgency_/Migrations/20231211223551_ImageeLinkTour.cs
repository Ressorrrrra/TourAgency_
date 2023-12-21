using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourAgency_
{
    /// <inheritdoc />
    public partial class ImageeLinkTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Tours",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Tours");
        }
    }
}
