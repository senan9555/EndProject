
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using EndProject.Models;
using EndProject.DAL;
using Microsoft.AspNetCore.Authorization;
using EndProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EndProject.Controllers
{
    [Authorize(Roles = "HeadAdmin,Admin")]

    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            Kassa kassa = await _db.Kassas.FirstOrDefaultAsync();
            ViewBag.InComeCount = _db.Incomes.Sum(x=>x.Money);
            ViewBag.ExpenditureCount = _db.Expenses.Sum(x=>x.Money);
            ViewBag.PaidedSalaryCount = _db.Wages.Sum(x=>x.Money);
            return View(kassa);
        }

    }
}
