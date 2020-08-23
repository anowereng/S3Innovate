using TimeSeriesChart.Data.Repository;

namespace TimeSeriesChart.Data.UnitOfWork
{
    public interface ITimeSeriesChartUnitOfWork
    {
         IBuildingRepository BuildingRepository { get;  }
         IDataFieldRepository DataFieldRepository { get;  }
         IObjectItemRepository ObjectItemRepository { get; }
         IReadingRepository ReadingRepository { get; }
         void Save();
    }
}
