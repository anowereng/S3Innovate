using System.Linq;
using System.Threading.Tasks;
using TimeSeriesChart.API.Data;
using TimeSeriesChart.Data.Contexts;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.API
{
    public class Seed
    {

        public static async Task Initialize(string _connectionString, string migrationAssemblyName)
        {
            var context = new TimeseriesContext(_connectionString, migrationAssemblyName);

            context.Database.EnsureCreated();

            if (!context.Buildings.Any())
            {
                /*Building  Data*/
                var buildings_data = await SeedHelper.SeedData<Building>("seed.buildings.json");
                _ = context.AddRangeAsync(buildings_data);

                /*Datafield  Data*/
                var datafield_data = await SeedHelper.SeedData<DataField>("seed.datafield.json");
                _ = context.AddRangeAsync(datafield_data);

                /*object item  Data*/
                var object_item_data = await SeedHelper.SeedData<ObjectItem>("seed.object-items.json");
                _ = context.AddRangeAsync(object_item_data);

                context.SaveChanges();
            }

        }
    }
}
