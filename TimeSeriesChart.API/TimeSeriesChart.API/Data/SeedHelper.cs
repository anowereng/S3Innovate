using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSeriesChart.API.Data
{
        public static class SeedHelper
        {
            public static async Task<List<TEntity>> SeedData<TEntity>(string fileName)
            {
                var result = new List<TEntity>();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string json = await reader.ReadToEndAsync();
                    result = JsonConvert.DeserializeObject<List<TEntity>>(json);
                }

                return result;
            }
        }
    }

