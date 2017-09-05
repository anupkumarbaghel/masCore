using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class AddLUNNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractorName",
                table: "IndentTables");

            migrationBuilder.AddColumn<string>(
                name: "LUNOrderNo",
                table: "MeasurementBooks",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LUNOrderNo",
                table: "MeasurementBooks");

            migrationBuilder.AddColumn<string>(
                name: "ContractorName",
                table: "IndentTables",
                maxLength: 200,
                nullable: true);
        }
    }
}
