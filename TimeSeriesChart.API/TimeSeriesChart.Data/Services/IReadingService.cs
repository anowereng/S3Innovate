using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.services
{
    public interface IReadingService
    {
        IList<Building> AllBuildings();
        IList<DataField> AllDataFields();
        IList<ObjectItem> AllObjectItems();
    }
}
