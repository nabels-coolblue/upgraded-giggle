using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UpgradedGiggle.Models;

namespace UpgradedGiggle.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            var users = new List<User>();

            var random = new Random();

            users.Add(new User() { Name = "tangent", NumberOfLines = random.Next(1, 2048) });
            users.Add(new User() { Name = "alpha", NumberOfLines = random.Next(1, 2048) });
            users.Add(new User() { Name = "azimuth", NumberOfLines = random.Next(1, 2048) });
            users.Add(new User() { Name = "literal", NumberOfLines = random.Next(1, 2048) });
            
            return Json(
                new string[][] {
                    users.Select(user => user.Name).ToArray(),
                    users.Select(user => user.NumberOfLines.ToString()).ToArray(),
                }
            );
        }
    }
}
