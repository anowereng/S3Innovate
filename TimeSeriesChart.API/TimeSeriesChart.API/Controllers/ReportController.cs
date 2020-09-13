using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesChart.Report;

namespace TimeSeriesChart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetReport()
        {
            ReportViewerRdlc report = new ReportViewerRdlc();
            var result =  report.RptPO();

            //var bytes = reportViewer.LocalReport.Render("application/pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            return Ok(result);
            //return File(bytes, "application/pdf")
 }
    }
}
