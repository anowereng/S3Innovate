using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSeriesChart.API.viewmodel;
using TimeSeriesChart.Data.Models;
using TimeSeriesChart.Data.services;

namespace TimeSeriesChart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadingsController : ControllerBase
    {
        private IReadingService _readingService;
        public ReadingsController(IReadingService readingService)
        {
            _readingService = readingService;
        }

       [HttpGet]
        public ActionResult<ReadingsModel> GetTotalReadings(int objectid, int buildid, int datafieldid, DateTime dtfrom, DateTime dtto)
        {
            var result = new List<ReadingsData>();
            var datalist = _readingService.GetTimeStampValue(objectid, buildid,  datafieldid, Convert.ToDateTime(dtfrom), Convert.ToDateTime(dtto)).ToList();
            if (datalist.Count > 0) {
                var labellist = _readingService.GetTimeStampLabel().ToList();

                foreach (Reading x in datalist)
                {
                    var data = datalist.Where(z => z.Timestamp.ToString("dd-MMM-yyyy") == x.Timestamp.ToString("dd-MMM-yyyy")).Select(d => d.value).ToArray();
                    result.Add(new ReadingsData { label = x.Timestamp.ToString("dd-MMM-yyyy"), data = data });
                }
                return Ok(new ReadingsModel { data = result, label = labellist.ToArray() });
            }
            else
            {
                return BadRequest("Reading data are empty !!");
            }
           
        }
    }

}
