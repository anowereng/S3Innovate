using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.Data.Models;
using TimeSeriesChart.Data.UnitOfWork;

namespace TimeSeriesChart.Data.services
{
    public class ObjectItemService : IObjectItemService
    {
        private TimeSeriesChartUnitOfWork _timeseriesUnitOfWork;
        public ObjectItemService(TimeSeriesChartUnitOfWork timeseriesUnitOfWork)
        {
            _timeseriesUnitOfWork = timeseriesUnitOfWork;
        }

        public IList<ObjectItem> AllObjectItem()
        {
            var result = _timeseriesUnitOfWork.ObjectItemRepository.GetAll().ToList();
            return result;
        }
    }
}
