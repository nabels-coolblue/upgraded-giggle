using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UpgradedGiggle.LogFileParsing;

namespace UpgradedGiggle.Controllers
{
    public class AdminController : Controller
    {


        public IActionResult ReadLogFiles()
        {
            var logFileDiscoverer = new LogFileDiscoverer("", );

        }
    }
}
