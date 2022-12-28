using EndProject.DAL;
using EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    public class MailController : Controller
    {
       
        mail email;
        private readonly AppDbContext _db;
        public MailController(AppDbContext db)
        {
            email = new mail();
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EMailSender(int? id)
        {
            Employee employee = _db.Employees.FirstOrDefault(x=> x.Id == id);   
            return View(employee);
        }
        [HttpPost]
        public ActionResult EMailSender(string sendMailAdress, string subject, string body)
        {
            email.Mail(sendMailAdress, subject, body);
            ViewBag.Kontrol = "Mail Göndərildi";
            return View();
        }
        
    }
}
