﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MAS.Repository;

namespace MAS.Repository.Migrations
{
    [DbContext(typeof(MASDBContext))]
    partial class MASDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAS.Core.Domain.Indent.Indent", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("IndentDate");

                    b.Property<string>("IndentNumber")
                        .HasMaxLength(200);

                    b.Property<string>("IndentStatus")
                        .HasMaxLength(10);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("IssuedBy")
                        .HasMaxLength(200);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ProvidedBy")
                        .HasMaxLength(200);

                    b.Property<string>("ProvidedOn")
                        .HasMaxLength(200);

                    b.Property<string>("ProvidedTo")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("Indents");
                });

            modelBuilder.Entity("MAS.Core.Domain.Indent.IndentTable", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContractorName")
                        .HasMaxLength(200);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("HeadOfAccount")
                        .HasMaxLength(200);

                    b.Property<long>("IndentID");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Quantity");

                    b.Property<string>("SerialNo")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("IndentID");

                    b.ToTable("IndentTables");
                });

            modelBuilder.Entity("MAS.Core.Domain.MeasurementBook.MeasurementBook", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AggrementNumber")
                        .HasMaxLength(200);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("MBNumber")
                        .HasMaxLength(200);

                    b.Property<string>("MeasurementBookStatus")
                        .HasMaxLength(10);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("NameOfContractor")
                        .HasMaxLength(200);

                    b.Property<string>("PageNumber")
                        .HasMaxLength(10);

                    b.Property<string>("WorkOrderNumber")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("MeasurementBook");
                });

            modelBuilder.Entity("MAS.Core.Domain.MeasurementBook.MeasurementBookTable", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("HeadOfAccount");

                    b.Property<bool>("IsDelete");

                    b.Property<long>("MeasurementBookID");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Quantity");

                    b.Property<string>("SerialNumber");

                    b.HasKey("ID");

                    b.HasIndex("MeasurementBookID");

                    b.ToTable("MeasurementBookTable");
                });

            modelBuilder.Entity("MAS.Core.Domain.Indent.IndentTable", b =>
                {
                    b.HasOne("MAS.Core.Domain.Indent.Indent")
                        .WithMany("IndentTableCollection")
                        .HasForeignKey("IndentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAS.Core.Domain.MeasurementBook.MeasurementBookTable", b =>
                {
                    b.HasOne("MAS.Core.Domain.MeasurementBook.MeasurementBook")
                        .WithMany("MBTable")
                        .HasForeignKey("MeasurementBookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
