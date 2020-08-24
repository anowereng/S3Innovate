using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadingsController : ControllerBase
    {
        [HttpGet]
        public ReadingsModel GetTotalReadings()
        {
            var datalist = new List<ReadingsData>();
            datalist.Add(new ReadingsData { label = DateTime.Now.ToString("dd-MMM-yyyy"), data = new int[] { 6, 19, 6, 21, 7, 15 } });
            datalist.Add(new ReadingsData { label = DateTime.Now.ToString("dd-MMM-yyyy"), data = new int[] { -8, -6, -1, 2, -7, 6 } });
            datalist.Add(new ReadingsData { label = DateTime.Now.ToString("dd-MMM-yyyy"), data = new int[] { -4, 3, -5, -1, -6, -3 } });
            datalist.Add(new ReadingsData { label = DateTime.Now.ToString("dd-MMM-yyyy"), data = new int[] { 6, 2, 4, 6, 7, 7 } });

            List<string> labellist = new List<string>();

            for (int i = 0; i <=24; i++)
            {
                labellist.AddRange(new string[] { $" {i} : 00" }) ;
            }
            return new ReadingsModel { ReadingsModelList = datalist, Label = labellist.ToArray() };
        }


        public class ReadingsData
        {
            public int[] data { get; set; }
            public string label { get; set; }
        }

        public class ReadingsModel
        {
            public List<ReadingsData> ReadingsModelList { get; set; }
            public string[] Label { get; set; }
        }

    }

}
