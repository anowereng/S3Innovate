using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.services
{
    public interface IReadingService
    {
        IList<Reading> GetTimeStampValue(int objectid, int buildings, int datafieldid, DateTime dtfrom, DateTime dtto);
        IList<string> GetTimeStampLabel();
    }
}
