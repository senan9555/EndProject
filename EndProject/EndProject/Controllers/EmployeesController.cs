using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using EndProject.Helpers;
using Microsoft.AspNetCore.Authorization;
using EndProject.ViewModels;

namespace EndProject.Controllers
{
    [Authorize(Roles = "HeadAdmin,Admin")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        public EmployeesController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _db.Employees.Include(x=>x.Position).Where(x=>!x.IsDeactive).ToListAsync();
            return View(employees);
        }
        #region Create Get
        public async Task<IActionResult> Create()
        {
            ViewBag.Positions = await _db.Positions.Where(x=>!x.IsDeactive).ToListAsync();
            return View();
        }

        #endregion

        #region Create Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, int posId)
        {
           
            ViewBag.Positions = await _db.Positions.Where(x =>! x.IsDeactive).ToListAsync();
           
            employee.PositionId= posId;
          
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion

        #region Update Get
        public async Task<IActionResult> Update(int? id,int posId)
        {
            ViewBag.Positions = await _db.Positions.Where(x => !x.IsDeactive).ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Employee dbEmployee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (dbEmployee == null)
            {
                return BadRequest();
            }
            
            return View(dbEmployee);
        }
        #endregion

        #region Update Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Employee employee,int posId)
        {
            ViewBag.Positions = await _db.Positions.Where(x => !x.IsDeactive).ToListAsync();

            if (id == null)
            {
                return NotFound();
            }
            Employee dbEmployee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (dbEmployee == null)
            {
                return BadRequest();
            }
            //if (!ModelState.IsValid)
            //{
            //    return View(dbEmployee);
            //}
            dbEmployee.FullName = employee.FullName;
            dbEmployee.PositionId = posId;
            dbEmployee.Wage= employee.Wage;
            dbEmployee.Email= employee.Email;
            dbEmployee.PhoneNumber= employee.PhoneNumber;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return BadRequest();
            }
            return View();
        }
        #endregion

        #region Delete Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return BadRequest();
            }
            employee.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region SendMailAllEmployees
        public IActionResult SendAll()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendAllAsync(MessageVM messageVM)
        {
            List<Employee> employees = await _db.Employees.ToListAsync();

            foreach (var employee in employees)
            {
                await Helper.SendMessage("Admin", messageVM.Message, employee.Email);
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
