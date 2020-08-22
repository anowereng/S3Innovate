using System.Collections.Generic;
using TimeSeriesChart.API.Models;

namespace TimeSeriesChart.API.Repository
{
    public interface IBuildingRepository
    {
        void BuildingAdd(Building model);
        IEnumerable<Building> GetAll();
        void SaveChange();
    }
}
