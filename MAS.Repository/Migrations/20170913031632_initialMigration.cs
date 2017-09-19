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
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Admins",
                schema: "dbo",
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
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaterialNameWithDescription = table.Column<string>(nullable: true),
                    MaterialRate = table.Column<decimal>(nullable: false),
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
                name: "DTOOpeningBalances",
                schema: "dbo",
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

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "Admins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indents",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    HeadOfAccount = table.Column<string>(maxLength: 200, nullable: true),
                    IndentDate = table.Column<DateTime>(nullable: true),
                    IndentNumber = table.Column<string>(maxLength: 200, nullable: true),
                    IndentStatus = table.Column<string>(maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    IsReceive = table.Column<bool>(nullable: false),
                    IssuedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProvidedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ProvidedOn = table.Column<string>(maxLength: 200, nullable: true),
                    ProvidedTo = table.Column<string>(maxLength: 200, nullable: true),
                    Sequence = table.Column<decimal>(nullable: false),
                    StoreID = table.Column<int>(nullable: false),
                    SubmittedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Indents_Stores_StoreID",
                        column: x => x.StoreID,
                        principalSchema: "dbo",
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementBooks",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggrementNumber = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    HeadOfAccount = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    LUNOrderNo = table.Column<string>(maxLength: 200, nullable: true),
                    MBNumber = table.Column<string>(maxLength: 200, nullable: true),
                    MeasurementBookStatus = table.Column<string>(maxLength: 10, nullable: true),
                    MeasurementDate = table.Column<DateTime>(nullable: true),
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
                        principalSchema: "dbo",
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementBooks_Stores_StoreID2",
                        column: x => x.StoreID2,
                        principalSchema: "dbo",
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndentTables",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
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
                        principalSchema: "dbo",
                        principalTable: "Indents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndentTables_MasterRegisters_MasterRegisterID",
                        column: x => x.MasterRegisterID,
                        principalSchema: "dbo",
                        principalTable: "MasterRegisters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementBookTables",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
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
                        principalSchema: "dbo",
                        principalTable: "MasterRegisters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeasurementBookTables_MeasurementBooks_MeasurementBookID",
                        column: x => x.MeasurementBookID,
                        principalSchema: "dbo",
                        principalTable: "MeasurementBooks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indents_StoreID",
                schema: "dbo",
                table: "Indents",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_IndentTables_IndentID",
                schema: "dbo",
                table: "IndentTables",
                column: "IndentID");

            migrationBuilder.CreateIndex(
                name: "IX_IndentTables_MasterRegisterID",
                schema: "dbo",
                table: "IndentTables",
                column: "MasterRegisterID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBooks_StoreID",
                schema: "dbo",
                table: "MeasurementBooks",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBooks_StoreID2",
                schema: "dbo",
                table: "MeasurementBooks",
                column: "StoreID2");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBookTables_MasterRegisterID",
                schema: "dbo",
                table: "MeasurementBookTables",
                column: "MasterRegisterID");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementBookTables_MeasurementBookID",
                schema: "dbo",
                table: "MeasurementBookTables",
                column: "MeasurementBookID");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminID",
                schema: "dbo",
                table: "Stores",
                column: "AdminID");

            migrationBuilder.Sql(installIndentScript);
            migrationBuilder.Sql(installMBScript);
            migrationBuilder.Sql(installProcGetOpeningBalance);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndentTables",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MeasurementBookTables",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DTOOpeningBalances",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Indents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MasterRegisters",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MeasurementBooks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Admins",
                schema: "dbo");

            migrationBuilder.Sql(uninstallProcOpeningBalance);
            migrationBuilder.Sql(uninstallIndentScript);
            migrationBuilder.Sql(uninstallMBScript);

        }

        const string installMBScript = @"
            CREATE PROCEDURE [dbo].[usp_MakeDraftOpenMeasurementBook]
        @DraftMeasurementBookID BIGINT,@storeID INT
        AS
        BEGIN
        UPDATE dbo.MeasurementBookS SET MeasurementBookStatus='d' WHERE MeasurementBookStatus='o' AND StoreID=@storeID
        UPDATE dbo.MeasurementBookS SET MeasurementBookStatus='o' WHERE ID=@DraftMeasurementBookID AND StoreID=@storeID
        END
        ";

        const string installIndentScript = @"
             CREATE PROCEDURE [dbo].[usp_MakeDraftOpenIndent]
        @DraftIndentID BIGINT,@storeID INT
        AS
        BEGIN
        UPDATE dbo.Indents SET IndentStatus='d' WHERE IndentStatus='o' AND StoreID=@storeID
        UPDATE dbo.Indents SET IndentStatus='o' WHERE ID=@DraftIndentID AND StoreID=@storeID
        END
        ";

        const string uninstallMBScript = "DROP PROCEDURE [dbo].[usp_MakeDraftOpenMeasurementBook]";

        const string uninstallIndentScript = "DROP PROCEDURE [dbo].[usp_MakeDraftOpenIndent]";

        const string installProcGetOpeningBalance = @"
           CREATE PROCEDURE dbo.usp_GetOpeningBalance
 @StoreID BIGINT
,@LastDate DATE
AS
BEGIN
select ReceiveTable.ID,(ReceiveTable.Quanity-ISNULL(IssueTable.Quantity,0)) AS OpeningBalance From (
select ID,MaterialNameWithDescription,sum(Quantity) AS Quanity from (
select mr.ID,mr.MaterialNameWithDescription, it.Quantity from dbo.indents i
  left join dbo.IndentTables it on i.ID=it.IndentID 
  left join dbo.MasterRegisters mr on mr.ID=it.MasterRegisterID
 where i.isreceive=1 and i.StoreID=@StoreID and i.SubmittedDate<@LastDate
 --and mr.MaterialNameWithDescription='Cycle'
 UNION ALL
 select mr.ID, mr.MaterialNameWithDescription,mt.Quantity from dbo.MeasurementBooks mb
 join dbo.MeasurementBookTables mt on mt.MeasurementBookID=mb.id
 join  dbo.MasterRegisters mr on mr.ID=mt.MasterRegisterID
 where  mb.StoreID=@StoreID and mb.MeasurementDate<@LastDate
 ) foo 
 group by MaterialNameWithDescription,ID)ReceiveTable
  left join
 (
 select mr.ID,mr.MaterialNameWithDescription,sum(it.Quantity) AS Quantity from dbo.indents i
  left join dbo.IndentTables it on i.ID=it.IndentID 
  left join dbo.MasterRegisters mr on mr.ID=it.MasterRegisterID
 where i.isreceive=0 and i.StoreID=@StoreID and i.SubmittedDate<@LastDate
 group by mr.MaterialNameWithDescription,mr.ID)IssueTable
 ON ReceiveTable.ID=IssueTable.id

 END
        ";

        const string uninstallProcOpeningBalance = "DROP PROCEDURE [dbo].[usp_GetOpeningBalance]";



    }
}
