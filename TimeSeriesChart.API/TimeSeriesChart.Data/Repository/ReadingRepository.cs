using System.Collections.Generic;
using System.Linq;
using TimeSeriesChart.Data.Contexts;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Repository
{
    public class ReadingRepository : IReadingRepository
    {
        private TimeseriesContext _context;
  
        public ReadingRepository(TimeseriesContext context) { _context = context; 
        
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void ReadingAdd(Reading model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Reading> GetAll()
        {
            return _context.Readings.ToList();
        }

        public void SaveChange()
        {
            throw new System.NotImplementedException();
        }
    }
}
