using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    public class VitrinController : Controller
    {
        private readonly AppDbContext _db;
        public VitrinController(AppDbContext db)
        {
            _db= db;
        }
        public async Task<IActionResult> Index()
        {
            List<Showcase> showcases = await _db.Showcases.Include(x=>x.Category).ToListAsync();
            return View(showcases);
        }
        #region Create Get

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View();
        }

        #endregion

        #region Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Showcase showcase, int catId)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Showcases.AnyAsync(x => x.Name == showcase.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu Vitrin Artıq Mövcuddur");
                return View();
            }
            showcase.CategoryId = catId;
            await _db.Showcases.AddAsync(showcase);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Update Get

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Showcase dbShowcase = await _db.Showcases.FirstOrDefaultAsync(x => x.Id == id);
            if (dbShowcase == null)
            {
                return NotFound();
            }
            return View(dbShowcase);
        }

        #endregion

        #region Update Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Showcase showcase, int catId)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Showcase dbShowcase = await _db.Showcases.FirstOrDefaultAsync(x => x.Id == id);
            if (dbShowcase == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(dbShowcase);
            }
            bool isExist = await _db.Showcases.AnyAsync(x => x.Name == showcase.Name && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu Vitrin Artıq Mövcuddur");
                return View(dbShowcase);
            }
            dbShowcase.CategoryId = catId;
            dbShowcase.Name = showcase.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Showcase showcase = await _db.Showcases.FirstOrDefaultAsync(x => x.Id == id);
            if (showcase == null)
            {
                return BadRequest();
            }
            if (showcase.IsDeactive)
            {
                showcase.IsDeactive = false;
            }
            else
            {
                showcase.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
