using EndProject.DAL;
using EndProject.Models;
using EndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    public class MedicineController : Controller
    {
        private readonly AppDbContext _db;
     
        public MedicineController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Medicine> medicines = await _db.Medicines.Include(x=>x.Category).ToListAsync();
            return View(medicines);
        }
        #region Create Get

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await  _db.Categories.ToListAsync();
            return View();
        }

        #endregion

        #region Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medicine medicine,int catId)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Medicines.AnyAsync(x => x.Name == medicine.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu Dərman Artıq Mövcuddur");
                return View();
            }
            medicine.CategoryId = catId;
            await _db.Medicines.AddAsync(medicine);
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
            Medicine dbMedicine  = await _db.Medicines.FirstOrDefaultAsync(x=> x.Id == id);
            if(dbMedicine == null)
            {
                return NotFound();
            }
            return View(dbMedicine); 
        }

        #endregion

        #region Update Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,Medicine medicine,int catId)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Medicine dbMedicine = await _db.Medicines.FirstOrDefaultAsync(x => x.Id == id);
            if (dbMedicine == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(dbMedicine);
            }
            bool isExist = await _db.Medicines.AnyAsync(x => x.Name == medicine.Name&&x.Id!=id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu Dərman Artıq Mövcuddur");
                return View(dbMedicine);
            }
            dbMedicine.CategoryId = catId;
            dbMedicine.Name = medicine.Name;
            dbMedicine.Description= medicine.Description;
            dbMedicine.Price= medicine.Price;
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
            Medicine medicine = await _db.Medicines.FirstOrDefaultAsync(x => x.Id == id);
            if (medicine == null)
            {
                return BadRequest();
            }
            if (medicine.IsDeactive)
            {
                medicine.IsDeactive = false;
            }
            else
            {
                medicine.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
