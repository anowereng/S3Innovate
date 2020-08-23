using System;
using System.Collections.Generic;
using System.Linq;
using TimeSeriesChart.Data.Models;
using TimeSeriesChart.Data.UnitOfWork;

namespace TimeSeriesChart.Data.services
{
    public class ReadingService : IReadingService
    {
        private TimeSeriesChartUnitOfWork _timeseriesUnitOfWork;
        public ReadingService(TimeSeriesChartUnitOfWork timeseriesUnitOfWork)
        {
            _timeseriesUnitOfWork = timeseriesUnitOfWork;
        }

        public IList<Building> AllBuildings()
        {
            var result = _timeseriesUnitOfWork.BuildingRepository.GetAll().ToList();
            return result;
        }

        public IList<DataField> AllDataFields()
        {
            throw new NotImplementedException();
        }

        public IList<ObjectItem> AllObjectItems()
        {
            throw new NotImplementedException();
        }

        public IList<Building> GetBuildings()
        {
            throw new NotImplementedException();
        }
    }
}
