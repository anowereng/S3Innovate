using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSeriesChart.API.viewmodel
{
    public class ReadingsModel
    {
            public IList<ReadingsData> data { get; set; }
            public string[] label { get; set; }
    }
}
