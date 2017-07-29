using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class addDeleteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MeasurementBookTables",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MeasurementBooks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "IndentTables",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Indents",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MeasurementBookTables");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MeasurementBooks");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "IndentTables");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Indents");
        }
    }
}
