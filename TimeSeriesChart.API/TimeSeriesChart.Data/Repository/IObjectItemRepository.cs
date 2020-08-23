using System.Collections.Generic;
using TimeSeriesChart.Data.Models;

namespace TimeSeriesChart.Data.Repository
{
    public interface IObjectItemRepository
    {
        void ObjectItemAdd(ObjectItem model);
        IEnumerable<ObjectItem> GetAll();
        void SaveChange();
    }
}
