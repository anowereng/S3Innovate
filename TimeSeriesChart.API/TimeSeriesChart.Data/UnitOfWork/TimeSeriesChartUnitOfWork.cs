using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSeriesChart.Data.Contexts;
using TimeSeriesChart.Data.Repository;
using TimeSeriesChart.Data.UnitOfWork;

namespace TimeSeriesChart.Data.UnitOfWork
{
    public class TimeSeriesChartUnitOfWork : ITimeSeriesChartUnitOfWork
    {
        private TimeseriesContext _context;

        public IBuildingRepository BuildingRepository { get; private set; }
        public IDataFieldRepository DataFieldRepository { get; private set; }
        public IObjectItemRepository ObjectItemRepository { get; private set; }
        public IReadingRepository ReadingRepository { get; private set; }

        public TimeSeriesChartUnitOfWork(string connectionString, string migrationAssemblyName)
        {
            _context = new TimeseriesContext(connectionString, migrationAssemblyName);

            BuildingRepository = new BuildingRepository(_context);
            DataFieldRepository = new DataFieldRepository(_context);
            ObjectItemRepository = new ObjectItemRepository(_context);
            ReadingRepository = new ReadingRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}