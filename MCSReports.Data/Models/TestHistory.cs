using System;
using System.Collections.Generic;
using System.Text;

namespace MCSReportData.Models
{
    public class TestHistory
    {
        public string Stage { get; set; }
        public string ProductName { get; set; }
        public string ModuleName { get; set; }
        public string AssemblyName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public string Outcome { get; set; }
        public string StationName { get; set; }
        public string Operator { get; set; }
        public string SiteName { get; set; }
    }


}
