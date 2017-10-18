using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class addMeasurementBookExtraBillFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                schema: "dbo",
                table: "MeasurementBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillMBNo",
                schema: "dbo",
                table: "MeasurementBooks",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillNo",
                schema: "dbo",
                table: "MeasurementBooks",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillPageNo",
                schema: "dbo",
                table: "MeasurementBooks",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillDate",
                schema: "dbo",
                table: "MeasurementBooks");

            migrationBuilder.DropColumn(
                name: "BillMBNo",
                schema: "dbo",
                table: "MeasurementBooks");

            migrationBuilder.DropColumn(
                name: "BillNo",
                schema: "dbo",
                table: "MeasurementBooks");

            migrationBuilder.DropColumn(
                name: "BillPageNo",
                schema: "dbo",
                table: "MeasurementBooks");
        }
    }
}
