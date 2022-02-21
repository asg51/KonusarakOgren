using Business.Abstract;
using Entities.Concrete;
using Entities.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    public class AuthController : Controller
    {
        private IAdminService adminService;
        public AuthController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AdminRequest adminRequest)
        {
            Admin admin = this.adminService.Get(x => x.Name == adminRequest.Name && x.Password == adminRequest.Password);
            if (admin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,adminRequest.Name)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("List", "QuizList");
            }
            return View();
        }
    }
}
