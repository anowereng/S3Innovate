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
        //ReadingsData


        public object GetTimeStampValue()  
        {
            var result = _timeseriesUnitOfWork.ReadingRepository.GetAll().Select(x => x.value).ToArray();
            return result;
        }
        public IList<string> GetTimeStamp()
        {
            List<string> labellist = new List<string>();

            for (int i = 0; i <= 24; i++)
            {
                labellist.AddRange(new string[] { $" {i} : 00" });
            }

            return labellist;
        }
    }
}
