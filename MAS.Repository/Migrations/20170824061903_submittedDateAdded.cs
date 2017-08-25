using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class submittedDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MeasurementDate",
                table: "MeasurementBooks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReceive",
                table: "Indents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedDate",
                table: "Indents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementDate",
                table: "MeasurementBooks");

            migrationBuilder.DropColumn(
                name: "IsReceive",
                table: "Indents");

            migrationBuilder.DropColumn(
                name: "SubmittedDate",
                table: "Indents");
        }
    }
}
