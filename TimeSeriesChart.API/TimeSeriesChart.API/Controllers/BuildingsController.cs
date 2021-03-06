﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSeriesChart.Data.services;

namespace TimeSeriesChart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingsController : ControllerBase
    {
        private IBuildingService _readingService;
        public BuildingsController(IBuildingService readingService) {
            _readingService = readingService;
        }


        [HttpGet]
        public ActionResult<ReadingService> Get()
        {
            try
            {
                var result = _readingService.AllBuildings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
           
        }
    }
}
