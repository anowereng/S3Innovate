using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSeriesChart.Data.services;

namespace TimeSeriesChart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjectItemController : ControllerBase
    {
        private IObjectItemService _ObjectItemService;
        public ObjectItemController(IObjectItemService ObjectItemService) {
            _ObjectItemService = ObjectItemService;
        }


        [HttpGet]
        public ActionResult<ObjectItemService> Get()
        {
            try
            {
                var result = _ObjectItemService.AllObjectItem();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
           
        }
    }
}
