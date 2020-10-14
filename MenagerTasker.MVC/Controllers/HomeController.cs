using MenagerTasker.Core.Data;
using MenagerTasker.Core.Entities;
using MenagerTasker.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace MenagerTasker.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManagerTaskerContext _context;
        private readonly DateTime overdueDateTime = DateTime.Now.AddHours(2);

        public HomeController(ManagerTaskerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["OverdueDateTime"] = overdueDateTime;
            Manager manager = _context.Managers
                        .Include(m => m.Tasks)
                        .FirstOrDefault();
            return View(manager);
        }

        public IActionResult OverdueTaskList()
        {
            var manager = _context.Managers
                            .AsNoTracking()
                            .Include(m => m.Tasks)
                            .Select(m => new ManagerIncludeOverdueTasks
                            {
                                ManagerFullName = m.FullName,
                                OverdueTasks = m.Tasks
                                                .Where(t => overdueDateTime >= t.EndDate && t.Status == Core.TaskStatus.Created)
                                                .Select(t => new OverdueTask { Name = t.Name, EndDate = t.EndDate })
                            })
                            .FirstOrDefault();

            return View(manager);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
