using System.Collections.Generic;
using System.Linq;
using TimeSeriesChart.API.Contexts;
using TimeSeriesChart.API.Models;

namespace TimeSeriesChart.API.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        private TimeseriesContext _context;
        public BuildingRepository(TimeseriesContext context) { _context = context; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void BuildingAdd(Building model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Building> GetAll()
        {
            return _context.Buildings.ToList();
        }

        public void SaveChange()
        {
            throw new System.NotImplementedException();
        }
    }
}
