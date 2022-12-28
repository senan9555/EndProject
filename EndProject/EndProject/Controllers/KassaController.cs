using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    public class KassaController : Controller
    {
        private readonly AppDbContext _db;
        public KassaController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Kassa> kassa = await _db.Kassas.ToListAsync();
            return View(kassa);
        }
    }
}
