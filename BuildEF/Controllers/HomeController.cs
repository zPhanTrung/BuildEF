using BuildEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Service.Impl;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entity;

namespace BuildEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ShoppingDb db)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime start = DateTime.Parse("2022-05-01");
            DateTime end = DateTime.Parse("2022-05-30");
            StatisticsService statisticsService = HttpContext.RequestServices.GetService<StatisticsService>();
            try
            {
                var res = statisticsService.StatisticSaleProductAmount(start, end);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
