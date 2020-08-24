
using Microsoft.EntityFrameworkCore;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Contexts
{
    public class TimeseriesContext : DbContext, ITimeseriesContext
    {
        private string _connectionstring;
        private string _migrationAssemblyName;
        public TimeseriesContext(string connstring, string migrationAssemblyName)
        {
            _connectionstring = connstring;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            if (!optionbuilder.IsConfigured)
            {
                optionbuilder.UseSqlServer(_connectionstring, m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionbuilder);
        }

        public TimeseriesContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reading>()
             .Property(s => s.Timestamp)
             .HasDefaultValueSql("GetDate()");

            builder.Entity<Reading>().HasNoKey();

        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DataField> DataFields { get; set; }
        public DbSet<ObjectItem> ObjectItems { get; set; }
        public DbSet<Reading> Readings { get; set; }
        
    }
}
