using System.Collections.Generic;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Repository
{
    public interface IBuildingRepository
    {
        void BuildingAdd(Building model);
        IEnumerable<Building> GetAll();
        void SaveChange();
    }
}
