using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MAS.Repository;

namespace MAS.Repository.Migrations
{
    [DbContext(typeof(MASDBContext))]
    [Migration("20170726150951_addIndentStatusColumn")]
    partial class addIndentStatusColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ContractorName");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("HeadOfAccount");

                    b.Property<long>("IndentID");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Quantity");

                    b.Property<string>("SerialNo");

                    b.HasKey("ID");

                    b.HasIndex("IndentID");

                    b.ToTable("IndentTables");
                });

            modelBuilder.Entity("MAS.Core.Domain.MeasurementBook.MeasurementBook", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AggrementNumber");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("MBNumber");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("NameOfContractor");

                    b.Property<string>("PageNumber");

                    b.Property<string>("WorkOrderNumber");

                    b.HasKey("ID");

                    b.ToTable("MeasurementBooks");
                });

            modelBuilder.Entity("MAS.Core.Domain.MeasurementBook.MeasurementBookTable", b =>
                {
                    b.Property<long>("MeasurementBookTableID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("HeadOfAccount");

                    b.Property<long>("ID");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("Quantity");

                    b.Property<string>("SerialNumber");

                    b.HasKey("MeasurementBookTableID");

                    b.HasIndex("ID");

                    b.ToTable("MeasurementBookTables");
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
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
