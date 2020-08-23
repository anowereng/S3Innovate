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
        private TimeSeriesChartUnitOfWork _timeseriesUnitOfWork;
        public BuildingService(TimeSeriesChartUnitOfWork timeseriesUnitOfWork)
        {
            _timeseriesUnitOfWork = timeseriesUnitOfWork;
        }

        public IList<Building> AllBuildings()
        {
            var result = _timeseriesUnitOfWork.BuildingRepository.GetAll().ToList();
            return result;
        }
    }
}
