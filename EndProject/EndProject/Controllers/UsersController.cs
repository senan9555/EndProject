using EndProject.DAL;
using EndProject.Helpers;
using EndProject.Models;
using EndProject.ViewModels;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EndProject.Helpers.Helper;

namespace EndProject.Controllers
{
    [Authorize(Roles = "HeadAdmin,Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,AppDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM
                {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    Id = user.Id,
                    IsDeactive = user.IsDeactive,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                };
                userVMs.Add(userVM);
            }
            return View(userVMs);
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
        public async Task<IActionResult> Create(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser
            {
                UserName = register.UserName,
                Email = register.Email,
                FullName = register.FullName,
            };
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();

            }
            await _userManager.AddToRoleAsync(appUser, Helper.Roles.Admin.ToString());
            return RedirectToAction("Index");
        }
        #endregion

        #region Update Get

        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            List<string> roles = new List<string>();
            roles.Add(Helper.Roles.HeadAdmin.ToString());
            roles.Add(Helper.Roles.Admin.ToString());
            string oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            UpdateVM dbUpdateVM = new UpdateVM
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Role = oldRole,
                Roles = roles,
            };
            return View(dbUpdateVM);
        }

        #endregion

        #region Update Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, UpdateVM updateVM, string newRole)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            List<string> roles = new List<string>();
            roles.Add(Helper.Roles.HeadAdmin.ToString());
            roles.Add(Helper.Roles.Admin.ToString());
            string oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            UpdateVM dbUpdateVM = new UpdateVM
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Role = oldRole,
                Roles = roles,
            };
            if (!ModelState.IsValid)
            {
                return View(dbUpdateVM);
            }
            IdentityResult addIdentityResult = await _userManager.AddToRoleAsync(user, newRole);
            if (!addIdentityResult.Succeeded)
            {
                ModelState.AddModelError("", "Error");
                return View(dbUpdateVM);
            };
            IdentityResult removeIdentityResult = await _userManager.RemoveFromRoleAsync(user, oldRole);
            if (!removeIdentityResult.Succeeded)
            {
                ModelState.AddModelError("", "Error");
                return View(dbUpdateVM);
            };
            //bool isExist = await _db.Users.AnyAsync(x => x.Email == updateVM.Email || x.UserName == updateVM.UserName);
            //if (isExist)
            //{
            //    ModelState.AddModelError("", "Bu İstifadəçi Adı Vəya Email Artıq İstifadə olunub");
            //    return View(dbUpdateVM);
            //}
            user.FullName = updateVM.FullName;
            user.UserName = updateVM.UserName;
            user.Email = updateVM.Email;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        #endregion

        #region Reset Password Get
        public async Task<IActionResult> ResetPassword(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            return View();
        }
        #endregion

        #region Reset Password Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordVM resetPasswordVM)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, resetPasswordVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Activity

        public async Task<IActionResult> Activity(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
             AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            if (user.IsDeactive)
            {
                user.IsDeactive = false;
            }
            else
            {
                user.IsDeactive = true;
            }
           await _userManager.UpdateAsync(user);  
            return RedirectToAction("Index");
        }
        #endregion


        

    }
}
