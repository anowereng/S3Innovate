using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.Data.Models;
using TimeSeriesChart.Data.UnitOfWork;

namespace TimeSeriesChart.Data.services
{
    public class BuildingService : IBuildingService
    {
        private ITimeSeriesChartUnitOfWork _timeseriesUnitOfWork;
        public BuildingService(ITimeSeriesChartUnitOfWork timeseriesUnitOfWork)
        {
            _timeseriesUnitOfWork = timeseriesUnitOfWork;
        }

        public IList<Building> GetBuildings()
        {
            throw new NotImplementedException();
        }
    }
}
