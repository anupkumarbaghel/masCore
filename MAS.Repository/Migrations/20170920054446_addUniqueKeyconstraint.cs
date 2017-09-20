using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS.Repository.Migrations
{
    public partial class addUniqueKeyconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(createadminkeyunique);
            migrationBuilder.Sql(createstorekeyunique);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "unique_store_key",
                schema: "dbo",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "unique_admin_key",
                schema: "dbo",
                table: "Admins");
        }

        string createadminkeyunique = "ALTER TABLE dbo.admins ADD CONSTRAINT unique_admin_key UNIQUE([key]);";
        string createstorekeyunique= "ALTER TABLE dbo.stores ADD CONSTRAINT unique_store_key UNIQUE([key]);";
    }
}
