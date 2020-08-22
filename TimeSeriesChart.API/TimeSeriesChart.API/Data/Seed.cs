using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.API.Contexts;
using TimeSeriesChart.API.Models;

namespace TimeSeriesChart.API
{
    public class Seed
    {
        public static async Task Initialize(
            TimeseriesContext context
            )
        {
            context.Database.EnsureCreated();

            for (int i = 0; i < 10; i++)
            {
                var buildingname = new Building
                {
                    Location = $"Location-{i}"
                };
                var result = await context.AddAsync(buildingname);
                context.SaveChanges();
            }
        }
    }
}
