using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class createOpenDraftStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SerialNo",
                table: "IndentTables",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeadOfAccount",
                table: "IndentTables",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractorName",
                table: "IndentTables",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.Sql(InstallScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SerialNo",
                table: "IndentTables",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeadOfAccount",
                table: "IndentTables",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractorName",
                table: "IndentTables",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
            migrationBuilder.Sql(UninstallScript);
        }

        private const string InstallScript = @"
        CREATE PROCEDURE SP_MakeDraftOpen
        @DraftIndentID BIGINT
        AS
        BEGIN
        UPDATE Indents SET IndentStatus='d' WHERE IndentStatus='o'
        UPDATE Indents SET IndentStatus='o' WHERE ID=@DraftIndentID
        END
    ";
        private const string UninstallScript = @"
        DROP PROCEDURE SP_MakeDraftOpen;
    ";
    }
}
