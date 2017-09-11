using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MAS.Repository.Migrations
{
    public partial class headOfAccountFromTableToHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadOfAccount",
                table: "IndentTables");

            migrationBuilder.AddColumn<string>(
                name: "HeadOfAccount",
                table: "Indents",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DTOOpeningBalances",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpeningBalance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTOOpeningBalances", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTOOpeningBalances");

            migrationBuilder.DropColumn(
                name: "HeadOfAccount",
                table: "Indents");

            migrationBuilder.AddColumn<string>(
                name: "HeadOfAccount",
                table: "IndentTables",
                maxLength: 200,
                nullable: true);
        }
    }
}
