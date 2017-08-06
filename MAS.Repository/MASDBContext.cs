using Microsoft.EntityFrameworkCore;

namespace MAS.Repository
{
    public class MASDBContext : DbContext
    {
        public MASDBContext(DbContextOptions<MASDBContext> options) : base(options)
        {

        }

        public DbSet<MAS.Core.Domain.Indent.Indent> Indents { get; set; }
        public DbSet<MAS.Core.Domain.Indent.IndentTable> IndentTables { get; set; }
        public DbSet<MAS.Core.Domain.MeasurementBook.MeasurementBook> MeasurementBooks { get; set; }
        public DbSet<MAS.Core.Domain.MeasurementBook.MeasurementBookTable> MeasurementBookTables { get; set; }
        public DbSet<MAS.Core.Domain.Admin.Admin> Admins { get; set; }
        public DbSet<MAS.Core.Domain.Store.Store> Stores { get; set; }


    }
}
