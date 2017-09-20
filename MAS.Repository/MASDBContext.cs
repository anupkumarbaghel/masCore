using Microsoft.EntityFrameworkCore;

namespace MAS.Repository
{
    public class MASDBContext : DbContext
    {
        public MASDBContext(DbContextOptions<MASDBContext> options) : base(options)
        {

        }
      
        public DbSet<MAS.Core.Domain.Store.Indent.Indent> Indents { get; set; }
        public DbSet<MAS.Core.Domain.Store.Indent.IndentTable> IndentTables { get; set; }
        public DbSet<MAS.Core.Domain.Store.MeasurementBook.MeasurementBook> MeasurementBooks { get; set; }
        public DbSet<MAS.Core.Domain.Store.MeasurementBook.MeasurementBookTable> MeasurementBookTables { get; set; }
        public DbSet<MAS.Core.Domain.Admin.Admin> Admins { get; set; }
        public DbSet<MAS.Core.Domain.Store.Store> Stores { get; set; }
        public DbSet<MAS.Core.Domain.Store.MasterRegister.MasterRegister> MasterRegisters { get; set; }
        public DbSet<MAS.Core.DTO.DTOOpeningBalance> DTOOpeningBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity < MAS.Core.Domain.Store.Indent.Indent > ().ToTable("Indents",schema: "dbo");
            modelBuilder.Entity<MAS.Core.Domain.Store.Indent.IndentTable>().ToTable("IndentTables", schema: "dbo");
            modelBuilder.Entity<MAS.Core.Domain.Store.MeasurementBook.MeasurementBook>().ToTable("MeasurementBooks", schema: "dbo");
            modelBuilder.Entity<MAS.Core.Domain.Store.MeasurementBook.MeasurementBookTable>().ToTable("MeasurementBookTables", schema: "dbo");
            modelBuilder.Entity<MAS.Core.Domain.Admin.Admin>().ToTable("Admins", schema: "dbo");
            modelBuilder.Entity<MAS.Core.Domain.Store.Store > ().ToTable("Stores", schema: "dbo");
            modelBuilder.Entity<MAS.Core.Domain.Store.MasterRegister.MasterRegister>().ToTable("MasterRegisters", schema: "dbo");
            modelBuilder.Entity<MAS.Core.DTO.DTOOpeningBalance>().ToTable("DTOOpeningBalances", schema: "dbo");

            modelBuilder.Entity<MAS.Core.Domain.Admin.Admin>()
             .HasIndex(p => p.Key).IsUnique(true);

            modelBuilder.Entity<MAS.Core.Domain.Store.Store>()
             .HasIndex(p => p.Key).IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }


    }
}
