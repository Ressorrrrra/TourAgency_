﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourAgency_
{
    /// <inheritdoc />
    public partial class TransportToName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transport",
                table: "TransportTypes",
                newName: "userName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "TransportTypes",
                newName: "Transport");
        }
    }
}
