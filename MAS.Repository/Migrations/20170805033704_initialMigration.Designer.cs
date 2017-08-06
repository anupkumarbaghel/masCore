using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MAS.Repository;

namespace MAS.Repository.Migrations
{
    [DbContext(typeof(MASDBContext))]
    [Migration("20170805033704_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAS.Core.Domain.Admin.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Key")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("Admins");
                });

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

                    b.Property<int>("StoreID");

                    b.HasKey("ID");

                    b.HasIndex("StoreID");

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

                    b.Property<int>("StoreID");

                    b.Property<string>("WorkOrderNumber")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("StoreID");

                    b.ToTable("MeasurementBooks");
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

                    b.ToTable("MeasurementBookTables");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.Store", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Key")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("MAS.Core.Domain.Indent.Indent", b =>
                {
                    b.HasOne("MAS.Core.Domain.Store.Store")
                        .WithMany("IndentCollection")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAS.Core.Domain.Indent.IndentTable", b =>
                {
                    b.HasOne("MAS.Core.Domain.Indent.Indent")
                        .WithMany("IndentTableCollection")
                        .HasForeignKey("IndentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAS.Core.Domain.MeasurementBook.MeasurementBook", b =>
                {
                    b.HasOne("MAS.Core.Domain.Store.Store")
                        .WithMany("MeasurementBookCollection")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAS.Core.Domain.MeasurementBook.MeasurementBookTable", b =>
                {
                    b.HasOne("MAS.Core.Domain.MeasurementBook.MeasurementBook")
                        .WithMany("MBTable")
                        .HasForeignKey("MeasurementBookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.Store", b =>
                {
                    b.HasOne("MAS.Core.Domain.Admin.Admin")
                        .WithMany("StoreCollection")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
