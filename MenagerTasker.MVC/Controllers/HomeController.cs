using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MenagerTasker.MVC.Models;
using MenagerTasker.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace MenagerTasker.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManagerTaskerContext _context;

        public HomeController(ManagerTaskerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var manager = _context.Managers.Include(m => m.Tasks).FirstOrDefault();
            return View(manager);
        }

        public IActionResult OverdueTaskList()
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
