using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORS.database.Migrations
{
    /// <inheritdoc />
    public partial class add_location_to_regions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "latitude",
                schema: "public",
                table: "regions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                schema: "public",
                table: "regions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "names",
                schema: "public",
                table: "quarters",
                type: "text",
                nullable: false,
                oldClrType: typeof(Dictionary<string, string>),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                schema: "public",
                table: "regions");

            migrationBuilder.DropColumn(
                name: "longitude",
                schema: "public",
                table: "regions");

            migrationBuilder.AlterColumn<Dictionary<string, string>>(
                name: "names",
                schema: "public",
                table: "quarters",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
