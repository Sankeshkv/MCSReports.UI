using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCSReportData.Models;

namespace MCSReports.UI.ViewModels
{
    public class AssemblyViewModel
    {
        public List<TestHistory> TestHistory { get; set; }
        public List<ShipmentHistory> ShipmentHistory { get; set; }
    }
}
