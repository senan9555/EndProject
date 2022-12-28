using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    [Authorize(Roles = "HeadAdmin")]

    public class WagesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public WagesController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Wage> wages = await _db.Wages.ToListAsync();
            return View(wages);
        }
        #region Create Get
        public async Task<IActionResult> Create()
        {
            ViewBag.Employee = await _db.Employees.Where(x => !x.IsDeactive).ToListAsync();
            return View();
        }
        #endregion

        #region Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Wage wage)
        {
            ViewBag.Employee = await _db.Employees.ToListAsync();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Kassa kassa = await _db.Kassas.FirstOrDefaultAsync();
            kassa.LastModifiedBy = user.FullName;
            kassa.Balance += wage.Money;
            kassa.LastModifiedMoney = wage.Money;
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            await _db.Wages.AddAsync(wage);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
