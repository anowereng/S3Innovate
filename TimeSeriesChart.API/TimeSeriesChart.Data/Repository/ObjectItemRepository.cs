using System.Collections.Generic;
using System.Linq;
using TimeSeriesChart.Data.Contexts;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Repository
{
    public class ObjectItemRepository : IObjectItemRepository
    {
        private TimeseriesContext _context;
        public ObjectItemRepository(TimeseriesContext context) { _context = context; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void ObjectItemAdd(ObjectItem model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ObjectItem> GetAll()
        {
            return _context.ObjectItems.ToList();
        }

        public void SaveChange()
        {
            throw new System.NotImplementedException();
        }
    }
}
