using System;
using System.Collections.Generic;
using System.Text;

namespace MCSReportData.Models
{
    public class ShipmentHistory
    {
        public DateTime DateShipped { get; set; }
        public string CO { get; set; }
        public string Customer { get; set; }
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }
        public string CustomerPO { get; set; }
        public string DataSource { get; set; }


    }
}
