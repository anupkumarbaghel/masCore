using System;
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

            modelBuilder.Entity("MAS.Core.Domain.Admin.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Key")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<decimal>("Sequence");

                    b.HasKey("ID");

                    b.ToTable("Admins","dbo");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.Indent.Indent", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("HeadOfAccount")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("IndentDate");

                    b.Property<string>("IndentNumber")
                        .HasMaxLength(200);

                    b.Property<string>("IndentStatus")
                        .HasMaxLength(10);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<bool>("IsReceive");

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

                    b.Property<decimal>("Sequence");

                    b.Property<int>("StoreID");

                    b.Property<DateTime?>("SubmittedDate");

                    b.HasKey("ID");

                    b.HasIndex("StoreID");

                    b.ToTable("Indents","dbo");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.Indent.IndentTable", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<long>("IndentID");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("MasterRegisterID");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Quantity");

                    b.Property<decimal>("Sequence");

                    b.Property<string>("SerialNo")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("IndentID");

                    b.HasIndex("MasterRegisterID");

                    b.ToTable("IndentTables","dbo");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.MasterRegister.MasterRegister", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("MaterialNameWithDescription");

                    b.Property<decimal>("MaterialRate");

                    b.Property<string>("MaterialUnit")
                        .HasMaxLength(20);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Sequence");

                    b.Property<int>("SerialNumber");

                    b.Property<int>("StoreID");

                    b.HasKey("ID");

                    b.ToTable("MasterRegisters","dbo");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.MeasurementBook.MeasurementBook", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AggrementNumber")
                        .HasMaxLength(200);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("HeadOfAccount")
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LUNOrderNo")
                        .HasMaxLength(200);

                    b.Property<string>("MBNumber")
                        .HasMaxLength(200);

                    b.Property<string>("MeasurementBookStatus")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("MeasurementDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("NameOfContractor")
                        .HasMaxLength(200);

                    b.Property<string>("PageNumber")
                        .HasMaxLength(10);

                    b.Property<decimal>("Sequence");

                    b.Property<int>("StoreID");

                    b.Property<int?>("StoreID2");

                    b.Property<string>("WorkOrderNumber")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("StoreID");

                    b.HasIndex("StoreID2");

                    b.ToTable("MeasurementBooks","dbo");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.MeasurementBook.MeasurementBookTable", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("MasterRegisterID");

                    b.Property<long>("MeasurementBookID");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Quantity");

                    b.Property<decimal>("Sequence");

                    b.Property<string>("SerialNumber");

                    b.HasKey("ID");

                    b.HasIndex("MasterRegisterID");

                    b.HasIndex("MeasurementBookID");

                    b.ToTable("MeasurementBookTables","dbo");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.Store", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Key")
                        .HasMaxLength(1000);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<decimal>("Sequence");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Stores","dbo");
                });

            modelBuilder.Entity("MAS.Core.DTO.DTOOpeningBalance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("OpeningBalance");

                    b.HasKey("ID");

                    b.ToTable("DTOOpeningBalances","dbo");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.Indent.Indent", b =>
                {
                    b.HasOne("MAS.Core.Domain.Store.Store")
                        .WithMany("IndentCollection")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.Indent.IndentTable", b =>
                {
                    b.HasOne("MAS.Core.Domain.Store.Indent.Indent")
                        .WithMany("IndentTableCollection")
                        .HasForeignKey("IndentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MAS.Core.Domain.Store.MasterRegister.MasterRegister", "MasterRegister")
                        .WithMany()
                        .HasForeignKey("MasterRegisterID");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.MeasurementBook.MeasurementBook", b =>
                {
                    b.HasOne("MAS.Core.Domain.Store.Store")
                        .WithMany("MasterRegisterCollection")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MAS.Core.Domain.Store.Store")
                        .WithMany("MeasurementBookCollection")
                        .HasForeignKey("StoreID2");
                });

            modelBuilder.Entity("MAS.Core.Domain.Store.MeasurementBook.MeasurementBookTable", b =>
                {
                    b.HasOne("MAS.Core.Domain.Store.MasterRegister.MasterRegister", "MasterRegister")
                        .WithMany()
                        .HasForeignKey("MasterRegisterID");

                    b.HasOne("MAS.Core.Domain.Store.MeasurementBook.MeasurementBook")
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
