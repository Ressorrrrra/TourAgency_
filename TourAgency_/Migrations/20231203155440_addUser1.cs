using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourAgency_
{
    /// <inheritdoc />
    public partial class addUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Contracts_ContractId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ContractId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ContractId",
                table: "Requests",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Contracts_ContractId",
                table: "Requests",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
