using System.Collections.Generic;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Repository
{
    public interface IReadingRepository
    {
        void ReadingAdd(Reading model);
        IEnumerable<Reading> GetAll();
        void SaveChange();
    }
}
