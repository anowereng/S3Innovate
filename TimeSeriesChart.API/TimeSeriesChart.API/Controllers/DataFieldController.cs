using System;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesChart.Data.services;

namespace TimeSeriesChart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataFieldController : ControllerBase
    {
        private IDataFieldService _dataFieldService;
        public DataFieldController(IDataFieldService dataFieldService) {
            _dataFieldService = dataFieldService;
        }


        [HttpGet]
        public ActionResult<ObjectItemService> Get()
        {
            try
            {
                var result = _dataFieldService.AllDataField();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
           
        }
    }
}
