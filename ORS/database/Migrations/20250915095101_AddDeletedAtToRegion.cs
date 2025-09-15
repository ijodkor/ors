using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORS.database.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAtToRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "regions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "short_name",
                schema: "public",
                table: "regions",
                type: "jsonb",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "regions");

            migrationBuilder.DropColumn(
                name: "short_name",
                schema: "public",
                table: "regions");
        }
    }
}
