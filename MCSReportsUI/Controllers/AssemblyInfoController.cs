using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCSReports.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MCSReportData;

namespace MCSReports.UI.Controllers
{
    public class AssemblyInfoController : Controller
    {
        public IActionResult Index()
        {
            var model = new AssemblyViewModel();
            model.TestHistory = AssemblyData.GetTestModuleResultsData();
            model.ShipmentHistory = AssemblyData.GetShipmentHistory();

            return View(model);
        }
    }
}