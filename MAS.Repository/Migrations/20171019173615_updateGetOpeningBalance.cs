﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class updateGetOpeningBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(installProcGetOpeningBalance);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(uninstallProcOpeningBalance);
        }

        const string installProcGetOpeningBalance = @"
           alter PROCEDURE dbo.usp_GetOpeningBalance
 @StoreID BIGINT
,@LastDate DATE
AS
BEGIN
select ReceiveTable.ID,(ReceiveTable.Quanity-ISNULL(IssueTable.Quantity,0)) AS OpeningBalance From (
select ID,MaterialNameWithDescription,sum(Quantity) AS Quanity from (
select mr.ID,mr.MaterialNameWithDescription, it.Quantity from dbo.indents i
  left join dbo.IndentTables it on i.ID=it.IndentID 
  left join dbo.MasterRegisters mr on mr.ID=it.MasterRegisterID
 where i.isreceive=1 and i.StoreID=@StoreID and i.SubmittedDate<=@LastDate
 --and mr.MaterialNameWithDescription='Cycle'
 UNION ALL
 select mr.ID, mr.MaterialNameWithDescription,mt.Quantity from dbo.MeasurementBooks mb
 join dbo.MeasurementBookTables mt on mt.MeasurementBookID=mb.id
 join  dbo.MasterRegisters mr on mr.ID=mt.MasterRegisterID
 where  mb.StoreID=@StoreID and mb.MeasurementDate<=@LastDate
 ) foo 
 group by MaterialNameWithDescription,ID)ReceiveTable
  left join
 (
 select mr.ID,mr.MaterialNameWithDescription,sum(it.Quantity) AS Quantity from dbo.indents i
  left join dbo.IndentTables it on i.ID=it.IndentID 
  left join dbo.MasterRegisters mr on mr.ID=it.MasterRegisterID
 where i.isreceive=0 and i.StoreID=@StoreID and i.SubmittedDate<=@LastDate
 group by mr.MaterialNameWithDescription,mr.ID)IssueTable
 ON ReceiveTable.ID=IssueTable.id

 END
        ";

        const string uninstallProcOpeningBalance = "DROP PROCEDURE [dbo].[usp_GetOpeningBalance]";

    }
}
