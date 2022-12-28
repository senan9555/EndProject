using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    [Authorize(Roles = "HeadAdmin,Admin")]

    public class ExpensesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public ExpensesController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Expense> expenses = await _db.Expenses.Include(x=>x.AppUser).ToListAsync();
            return View(expenses);
        }
        #region Create
        public IActionResult Create()
        {
            return View();
        }

        #endregion

        #region Create Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Kassa kassa = await _db.Kassas.FirstOrDefaultAsync();
            kassa.LastModifiedBy = user.FullName;
            kassa.Balance -= expense.Money;
            kassa.LastModifiedMoney = expense.Money - expense.Money - expense.Money;
            kassa.LastModified = expense.For;
            kassa.LastModifiedTime = DateTime.UtcNow.AddHours(4);

            expense.StartTime = DateTime.UtcNow.AddHours(4);
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            expense.AppUserId = appUser.Id;
            await _db.Expenses.AddAsync(expense);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
