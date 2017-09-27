using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class AlterSPupdateSerialNumber2 : Migration
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

        IF(@InCommingSerialNumber=-1)
        BEGIN
             update dbo.MasterRegisters set SerialNumber=SerialNumber-1 where StoreID=@storeID 
		        AND SerialNumber>@PreviousSerialNumber
        END


		IF exists(select * from dbo.MasterRegisters where StoreID=@storeID and SerialNumber=@InCommingSerialNumber)
		BEGIN
		if(@PreviousSerialNumber is null)
		begin
		     update dbo.MasterRegisters set SerialNumber=SerialNumber+1 where StoreID=@storeID 
		and SerialNumber>=@InCommingSerialNumber
	
		end
	    else   IF(@PreviousSerialNumber>@InCommingSerialNumber)
		   BEGIN
        update dbo.MasterRegisters set SerialNumber=SerialNumber+1 where StoreID=@storeID 
		and SerialNumber>=@InCommingSerialNumber
		AND SerialNumber<@PreviousSerialNumber
		END
		else IF(@PreviousSerialNumber<@InCommingSerialNumber)
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
