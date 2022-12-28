using EndProject.DAL;
using EndProject.Helpers;
using EndProject.Models;
using EndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }

        #region Register Get

        public IActionResult Register()
        {
            return View();
        }

        #endregion

        #region Register Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser
            {
                UserName = registerVM.UserName,
                FullName = registerVM.FullName,
                Email = registerVM.Email,
            };
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError("Username", "İstifadəçi Adı Düzgün Daxil Edilməyib");
                ModelState.AddModelError("FullName", "Ad Soyad Düzgün Daxil Edilməyib");
                ModelState.AddModelError("Password", "Şifrə Minimum 8 Rəqəmdən İbarət Olmalıdır");

            }
            await _signInManager.SignInAsync(appUser, true);
            await _userManager.AddToRoleAsync(appUser, Helper.Roles.Admin.ToString());
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Login Get
        public async Task<IActionResult> Login()
        {
           
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            ViewBag.IsExistAdmin = false;
            HasAdmin hasAdmin = await _db.HasAdmins.FirstOrDefaultAsync();
            if (hasAdmin.HaSAdmin)
            {
                ViewBag.IsExistAdmin = true;
            }

            return View();
        }
        #endregion

        #region Login Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            ViewBag.IsExistAdmin = false;
            HasAdmin hasAdmin = await _db.HasAdmins.FirstOrDefaultAsync();
            if (hasAdmin.HaSAdmin)
            {
                ViewBag.IsExistAdmin = true;
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "İstifadəçi Adı Vəya Şifrə Yanlışdır");
                return View();
            }
            if (user.IsDeactive)
            {
                ModelState.AddModelError("UserName", "Bu İsdifadəçi Bloklanıb");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("UserName", "Bu İsdifadəçi 1 Dəqiqəlik Bloklanıb");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "İstifadəçi Adı Vəya Şifrə Yanlışdır");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region CreateAdmin

        public async Task<IActionResult> CreateHeadAdmin()
        {
            await CreateRoles();
            var result = await _userManager.FindByNameAsync("Admin");
            
            if(result == null)
            {
                AppUser appUser = new AppUser
                {
                    FullName = "Admin",
                    UserName = "Admin",
                    Email = "admin@admin.com"
                };
                IdentityResult identityResult = await _userManager.CreateAsync(appUser,"Admin123");
                if (!identityResult.Succeeded)
                {
                    foreach (IdentityError error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                await _userManager.AddToRoleAsync(appUser, "HeadAdmin");
            }
            else
            {
                return NotFound();
            }
            HasAdmin hasAdmin = await _db.HasAdmins.FirstOrDefaultAsync();
            hasAdmin.HaSAdmin = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        #endregion

        #region Create Roles
        public async Task CreateRoles()
        {
            if (!(await _roleManager.RoleExistsAsync(Helper.Roles.HeadAdmin.ToString())))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.HeadAdmin.ToString() });
            }
            if (!(await _roleManager.RoleExistsAsync(Helper.Roles.Admin.ToString())))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Roles.Admin.ToString() });
            }
        }
        #endregion


    }
}

