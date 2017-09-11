using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class HeadOfAccountFromTableToHeaderForMeasurementBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadOfAccount",
                table: "MeasurementBookTables");

            migrationBuilder.AddColumn<string>(
                name: "HeadOfAccount",
                table: "MeasurementBooks",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadOfAccount",
                table: "MeasurementBooks");

            migrationBuilder.AddColumn<string>(
                name: "HeadOfAccount",
                table: "MeasurementBookTables",
                nullable: true);
        }
    }
}
