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

    public class IncomesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public IncomesController(AppDbContext db,UserManager<AppUser>userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Income> incomes = await _db.Incomes.Include(x=>x.AppUser).ToListAsync();
            return View(incomes);
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
        public async Task<IActionResult> Create(Income income)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Kassa kassa = await _db.Kassas.FirstOrDefaultAsync();
            kassa.LastModifiedBy = user.FullName;
            kassa.Balance += income.Money;
            kassa.LastModifiedMoney= income.Money;
            kassa.LastModified = income.For;
            kassa.LastModifiedTime = DateTime.UtcNow.AddHours(4);

            income.StartTime = DateTime.UtcNow.AddHours(4);
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            income.AppUserId = appUser.Id;
            await _db.Incomes.AddAsync(income);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
