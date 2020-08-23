using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSeriesChart.Data.Models
{
    public class Reading
    {
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public float value { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("DataFieldId")]
        public virtual DataField DataField { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        [ForeignKey("ObjectId")]
        public ObjectItem Object { get; set; }
    }
}
