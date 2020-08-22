
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSeriesChart.API.Contexts;
using TimeSeriesChart.API.Models;

namespace TimeSeriesChart.API.Contexts
{
    public class TimeseriesContext : DbContext, ITimeseriesContext
    {
        private string _connectionString;
        public TimeseriesContext()
        {
            _connectionString = @"Server=Softify-PC2;Database=TimesSeriesDatabase;User Id=sa;Password=007;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reading>()
             .Property(s => s.Timestamp)
             .HasDefaultValueSql("GetDate()");

            builder.Entity<Reading>().HasKey(
               t => new { t.Timestamp}
           );

        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DataField> DataFields { get; set; }
        public DbSet<ObjectItem> ObjectItems { get; set; }
        public DbSet<Reading> Readings { get; set; }
        
    }
}
