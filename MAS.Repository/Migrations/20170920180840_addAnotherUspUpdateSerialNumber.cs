using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class addAnotherUspUpdateSerialNumber : Migration
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
            CREATE PROCEDURE [dbo].[usp_UpdateSerialNumberByOne]
        @InCommingSerialNumber INT,@storeID INT
        AS
        BEGIN
		IF exists(select * from dbo.MasterRegisters where StoreID=@storeID and SerialNumber=@InCommingSerialNumber)
        update dbo.MasterRegisters set SerialNumber=SerialNumber+1 where StoreID=@storeID and SerialNumber>=@InCommingSerialNumber
        END
        ";
        const string dropUspUpdateSerialNumber = @"DROP PROCEDURE [dbo].[usp_UpdateSerialNumberByOne]";
    }
}
