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
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Sequence = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MasterRegisters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaterialNameWithDescription = table.Column<string>(nullable: true),
                    MaterialUnit = table.Column<string>(maxLength: 20, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Sequence = table.Column<decimal>(nullable: false),
                    SerialNumber = table.Column<int>(nullable: false),
                    StoreID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterRegisters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Sequence = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stores_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    IssuedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProvidedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ProvidedOn = table.Column<string>(maxLength: 200, nullable: true),
                    ProvidedTo = table.Column<string>(maxLength: 200, nullable: true),
                    Sequence = table.Column<decimal>(nullable: false),
                    StoreID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Indents_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementBooks",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggrementNumber = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MBNumber = table.Column<string>(maxLength: 200, nullable: true),
                    MeasurementBookStatus = table.Column<string>(maxLength: 10, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    NameOfContractor = table.Column<string>(maxLength: 200, nullable: true),
                    PageNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Sequence = table.Column<decimal>(nullable: false),
                    StoreID = table.Column<int>(nullable: false),
                    StoreID2 = table.Column<int>(nullable: true),
                    WorkOrderNumber = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementBooks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeasurementBooks_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementBooks_Stores_StoreID2",
                        column: x => x.StoreID2,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MasterRegisterID = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Sequence = table.Column<decimal>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_IndentTables_MasterRegisters_MasterRegisterID",
                        column: x => x.MasterRegisterID,
                        principalTable: "MasterRegisters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementBookTables",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HeadOfAccount = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MasterRegisterID = table.Column<int>(nullable: true),
                    MeasurementBookID = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Sequence = table.Column<decimal>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementBookTables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeasurementBookTables_MasterRegisters_MasterRegisterID",
                        column: x => x.MasterRegisterID,
                        principalTable: "MasterRegisters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeasurementBookTables_MeasurementBooks_MeasurementBookID",
                        column: x => x.MeasurementBookID,
                        principalTable: "MeasurementBooks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indents_StoreID",
                table: "Indents",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_IndentTables_IndentID",
                table: "IndentTables",
                column: "IndentID");

            migrationBuilder.CreateIndex(
                name: "IX_IndentTables_MasterRegisterID",
                table: "IndentTables",
                column: "MasterRegisterID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBooks_StoreID",
                table: "MeasurementBooks",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBooks_StoreID2",
                table: "MeasurementBooks",
                column: "StoreID2");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBookTables_MasterRegisterID",
                table: "MeasurementBookTables",
                column: "MasterRegisterID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBookTables_MeasurementBookID",
                table: "MeasurementBookTables",
                column: "MeasurementBookID");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminID",
                table: "Stores",
                column: "AdminID");

            migrationBuilder.Sql(installIndentScript);
            migrationBuilder.Sql(installMBScript);
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
                name: "MasterRegisters");

            migrationBuilder.DropTable(
                name: "MeasurementBooks");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.Sql(uninstallIndentScript);
            migrationBuilder.Sql(uninstallMBScript);
        }


        const string installMBScript = @"
            CREATE PROCEDURE [dbo].[usp_MakeDraftOpenMeasurementBook]
        @DraftMeasurementBookID BIGINT,@storeID INT
        AS
        BEGIN
        UPDATE MeasurementBookS SET MeasurementBookStatus='d' WHERE MeasurementBookStatus='o' AND StoreID=@storeID
        UPDATE MeasurementBookS SET MeasurementBookStatus='o' WHERE ID=@DraftMeasurementBookID AND StoreID=@storeID
        END
        ";

        const string installIndentScript = @"
             CREATE PROCEDURE [dbo].[usp_MakeDraftOpenIndent]
        @DraftIndentID BIGINT,@storeID INT
        AS
        BEGIN
        UPDATE Indents SET IndentStatus='d' WHERE IndentStatus='o' AND StoreID=@storeID
        UPDATE Indents SET IndentStatus='o' WHERE ID=@DraftIndentID AND StoreID=@storeID
        END
        ";

        const string uninstallMBScript = "DROP PROCEDURE [dbo].[usp_MakeDraftOpenMeasurementBook]";

        const string uninstallIndentScript = "DROP PROCEDURE [dbo].[usp_MakeDraftOpenIndent]";


    }
}
