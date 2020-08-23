using System.Collections.Generic;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Repository
{
    public interface IDataFieldRepository
    {
        void DataFieldAdd(DataField model);
        IEnumerable<DataField> GetAll();
        void SaveChange();
    }
}
