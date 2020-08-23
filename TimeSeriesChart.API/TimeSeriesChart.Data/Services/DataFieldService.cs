using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.Data.Models;
using TimeSeriesChart.Data.UnitOfWork;

namespace TimeSeriesChart.Data.services
{
    public class DataFieldService : IDataFieldService
    {
        private TimeSeriesChartUnitOfWork _timeseriesUnitOfWork;
        public DataFieldService(TimeSeriesChartUnitOfWork timeseriesUnitOfWork)
        {
            _timeseriesUnitOfWork = timeseriesUnitOfWork;
        }

        public IList<DataField> AllDataField()
        {
            var result = _timeseriesUnitOfWork.DataFieldRepository.GetAll().ToList();
            return result;
        }
    }
}
