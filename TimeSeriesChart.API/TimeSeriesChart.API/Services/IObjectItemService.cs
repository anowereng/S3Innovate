using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.API.Models;

namespace TimeSeriesChart.API.services
{
    public interface IObjectItemService
    {
        IList<ObjectItem> ObjectItems();
    }
}
