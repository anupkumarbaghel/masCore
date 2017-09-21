using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class alterUpdateSerialNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(createUspUpdateSerialNumber);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(dropUspUpdateSerialNumber);
        }

        const string createUspUpdateSerialNumber = @"
            ALTER PROCEDURE [dbo].[usp_UpdateSerialNumberByOne]
        @InCommingSerialNumber INT,@storeID INT,@MasterRegisterID INT
        AS
        BEGIN
		DECLARE @PreviousSerialNumber INT=(select top 1 SerialNumber from dbo.MasterRegisters where ID=@MasterRegisterID)
		IF exists(select * from dbo.MasterRegisters where StoreID=@storeID and SerialNumber=@InCommingSerialNumber)
		BEGIN
	       IF(@PreviousSerialNumber>@InCommingSerialNumber)
		   BEGIN
        update dbo.MasterRegisters set SerialNumber=SerialNumber+1 where StoreID=@storeID 
		and SerialNumber>=@InCommingSerialNumber
		AND SerialNumber<@PreviousSerialNumber
		END
		IF(@PreviousSerialNumber<@InCommingSerialNumber)
		BEGIN
		 update dbo.MasterRegisters set SerialNumber=SerialNumber-1 where StoreID=@storeID 
		and SerialNumber<=@InCommingSerialNumber
		AND SerialNumber>@PreviousSerialNumber
		END
		END
        END
        ";
        const string dropUspUpdateSerialNumber = @"DROP PROCEDURE [dbo].[usp_UpdateSerialNumberByOne]";
    }
}
