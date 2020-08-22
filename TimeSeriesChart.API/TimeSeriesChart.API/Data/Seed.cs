using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.API.Contexts;
using TimeSeriesChart.API.Data;
using TimeSeriesChart.API.Models;

namespace TimeSeriesChart.API
{
    public class Seed
    {
        public static async Task Initialize()
        {
            var context = new TimeseriesContext();

            var result = context.Database.EnsureCreated();

            if (!result)
            {
                /*Building  Data*/
                var buildings_data = await SeedHelper.SeedData<Building>("seed.buildings.json");
                _ = context.AddRangeAsync(buildings_data);
                //context.SaveChanges();

                /*Datafield  Data*/
                var datafield_data = await SeedHelper.SeedData<DataField>("seed.datafield.json");
                _ = context.AddRangeAsync(datafield_data);
                //context.SaveChanges();

                /*object item  Data*/
                var object_item_data = await SeedHelper.SeedData<ObjectItem>("seed.object-items.json");
                _ = context.AddRangeAsync(object_item_data);

                context.SaveChanges();
            }

        }
    }
}
