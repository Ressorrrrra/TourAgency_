﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourAgency_
{
    /// <inheritdoc />
    public partial class ChangedCostToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Employees",
                newName: "userName");

            migrationBuilder.AlterColumn<int>(
                name: "TotalCost",
                table: "Contracts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Employees",
                newName: "Fullname");

            migrationBuilder.AlterColumn<string>(
                name: "TotalCost",
                table: "Contracts",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
