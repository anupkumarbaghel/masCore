using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MAS.Repository.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Indents",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IndentDate = table.Column<DateTime>(nullable: true),
                    IndentNumber = table.Column<string>(maxLength: 200, nullable: true),
                    IndentStatus = table.Column<string>(maxLength: 10, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    IssuedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProvidedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ProvidedOn = table.Column<string>(maxLength: 200, nullable: true),
                    ProvidedTo = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementBook",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggrementNumber = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MBNumber = table.Column<string>(maxLength: 200, nullable: true),
                    MeasurementBookStatus = table.Column<string>(maxLength: 10, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    NameOfContractor = table.Column<string>(maxLength: 200, nullable: true),
                    PageNumber = table.Column<string>(maxLength: 10, nullable: true),
                    WorkOrderNumber = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementBook", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IndentTables",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorName = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HeadOfAccount = table.Column<string>(maxLength: 200, nullable: true),
                    IndentID = table.Column<long>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SerialNo = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndentTables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IndentTables_Indents_IndentID",
                        column: x => x.IndentID,
                        principalTable: "Indents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementBookTable",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HeadOfAccount = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MeasurementBookID = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementBookTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeasurementBookTable_MeasurementBook_MeasurementBookID",
                        column: x => x.MeasurementBookID,
                        principalTable: "MeasurementBook",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndentTables_IndentID",
                table: "IndentTables",
                column: "IndentID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBookTable_MeasurementBookID",
                table: "MeasurementBookTable",
                column: "MeasurementBookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndentTables");

            migrationBuilder.DropTable(
                name: "MeasurementBookTable");

            migrationBuilder.DropTable(
                name: "Indents");

            migrationBuilder.DropTable(
                name: "MeasurementBook");
        }
    }
}
