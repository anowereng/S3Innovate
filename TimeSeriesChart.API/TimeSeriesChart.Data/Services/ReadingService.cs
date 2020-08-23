﻿using System;
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
        public IList<Reading> AllReading()
        {
            var result = _timeseriesUnitOfWork.ReadingRepository.GetAll().ToList();
            return result;
        }
    }
}
