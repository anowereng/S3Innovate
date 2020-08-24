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
        public IList<Reading> GetTimeStampValue(int objectid, int buildingid, int datafieldid, DateTime dtfrom, DateTime dtto)  
        {
            var result = _timeseriesUnitOfWork.ReadingRepository.GetAll().Where(x=>x.ObjectId==objectid && x.BuildingId== buildingid && (x.Timestamp > dtfrom && x.Timestamp < dtto)).ToList();
            return result;
        }
        public IList<string> GetTimeStampLabel()
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
