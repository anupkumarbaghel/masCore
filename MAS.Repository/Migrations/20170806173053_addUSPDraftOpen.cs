using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class addUSPDraftOpen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(installIndentScript);
            migrationBuilder.Sql(installMBScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
