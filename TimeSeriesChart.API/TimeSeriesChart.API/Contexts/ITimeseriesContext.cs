using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSeriesChart.API.Models;

namespace TimeSeriesChart.API.Contexts
{
    public interface ITimeseriesContext
    {
        DbSet<Building> Buildings { get; set; }
        DbSet<DataField> DataFields { get; set; }
        DbSet<ObjectItem> ObjectItems { get; set; }
        DbSet<Reading> Readings { get; set; }
    }
}
