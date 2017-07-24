using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MAS.Repository.Migrations
{
    public partial class initialmigration : Migration
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
                    IndentNumber = table.Column<string>(nullable: true),
                    IssuedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProvidedBy = table.Column<string>(nullable: true),
                    ProvidedOn = table.Column<string>(nullable: true),
                    ProvidedTo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementBooks",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggrementNumber = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MBNumber = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    NameOfContractor = table.Column<string>(nullable: true),
                    PageNumber = table.Column<string>(nullable: true),
                    WorkOrderNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementBooks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IndentTables",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HeadOfAccount = table.Column<string>(nullable: true),
                    IndentID = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SerialNo = table.Column<string>(nullable: true)
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
                name: "MeasurementBookTables",
                columns: table => new
                {
                    MeasurementBookTableID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HeadOfAccount = table.Column<string>(nullable: true),
                    ID = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementBookTables", x => x.MeasurementBookTableID);
                    table.ForeignKey(
                        name: "FK_MeasurementBookTables_MeasurementBooks_ID",
                        column: x => x.ID,
                        principalTable: "MeasurementBooks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndentTables_IndentID",
                table: "IndentTables",
                column: "IndentID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBookTables_ID",
                table: "MeasurementBookTables",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndentTables");

            migrationBuilder.DropTable(
                name: "MeasurementBookTables");

            migrationBuilder.DropTable(
                name: "Indents");

            migrationBuilder.DropTable(
                name: "MeasurementBooks");
        }
    }
}
