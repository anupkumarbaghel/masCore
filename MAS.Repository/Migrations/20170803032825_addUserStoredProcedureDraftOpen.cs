using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class addUserStoredProcedureDraftOpen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(inslallScriptMeasurementBookOpenDraft);
            migrationBuilder.Sql(installScriptIndentOpenDraft);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(uninstallScriptMeasurementOpenDraft);
            migrationBuilder.Sql(uninstallScritpIndentOepnDraft);
        }

        const string inslallScriptMeasurementBookOpenDraft = @"
            CREATE PROCEDURE [dbo].[usp_MakeDraftOpenMeasurementBook]
        @DraftMeasurementBookID BIGINT
        AS
        BEGIN
        UPDATE MeasurementBook SET MeasurementBookStatus='d' WHERE MeasurementBookStatus='o'
        UPDATE MeasurementBook SET MeasurementBookStatus='o' WHERE ID=@DraftMeasurementBookID
        END
     ";

        const string installScriptIndentOpenDraft = @"
             CREATE PROCEDURE [dbo].[usp_MakeDraftOpenIndent]
        @DraftIndentID BIGINT
        AS
        BEGIN
        UPDATE Indents SET IndentStatus='d' WHERE IndentStatus='o'
        UPDATE Indents SET IndentStatus='o' WHERE ID=@DraftIndentID
        END
      ";

        const string uninstallScriptMeasurementOpenDraft = "DROP PROCEDURE [dbo].[usp_MakeDraftOpenMeasurementBook]";
        const string uninstallScritpIndentOepnDraft = "DROP PROCEDURE [dbo].[usp_MakeDraftOpenIndent]";
    }
}
