using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    [Authorize(Roles = "HeadAdmin,Admin")]

    public class PositionsController : Controller
    {
        private readonly AppDbContext _db;
        public PositionsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Position>positions = await _db.Positions.ToListAsync();
            return View(positions);
        }
        #region Create Get

        public IActionResult Create()
        {
            return View();
        }

        #endregion

        #region Create Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _db.Positions.AddAsync(position);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion

        #region Update Get
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Position dbPosition = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPosition == null)
            {
                return BadRequest();
            }
            return View(dbPosition);
        }
        #endregion

        #region Update Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Position position)
        {
            if (id == null)
            {
                return NotFound();
            }
            Position dbPosition = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPosition == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbPosition);
            }
            //bool isExist = await _db.Services.AnyAsync(x => x.Title == service.Title && x.Id != id);
            //if (isExist)
            //{
            //    ModelState.AddModelError("Title", "This service already is exist");
            //    return View();
            //}
            dbPosition.Name = position.Name;
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
            Position position = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (position == null)
            {
                return BadRequest();
            }
            if (position.IsDeactive)
            {
                position.IsDeactive = false;
            }
            else
            {
                position.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
