using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.MeasurementBook;


namespace MAS.Repository
{
    public class MASDBContext : DbContext
    {
        public MASDBContext(DbContextOptions<MASDBContext> options) : base(options)
        {

        }

        public DbSet<MAS.Core.Domain.Indent.Indent> Indents { get; set; }
        public DbSet<MAS.Core.Domain.Indent.IndentTable> IndentTables { get; set; }
        public DbSet<MeasurementBook> MeasurementBooks { get; set; }
        public DbSet<MeasurementBookTable> MeasurementBookTables { get; set; }


    }
}
