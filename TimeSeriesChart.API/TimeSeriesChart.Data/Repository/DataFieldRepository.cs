using System.Collections.Generic;
using System.Linq;
using TimeSeriesChart.Data.Contexts;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Repository
{
    public class DataFieldRepository : IDataFieldRepository
    {
        private TimeseriesContext _context;
        public DataFieldRepository(TimeseriesContext context) { _context = context; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void DataFieldAdd(DataField model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DataField> GetAll()
        {
            return _context.DataFields.ToList();
        }

        public void SaveChange()
        {
            throw new System.NotImplementedException();
        }
    }
}
