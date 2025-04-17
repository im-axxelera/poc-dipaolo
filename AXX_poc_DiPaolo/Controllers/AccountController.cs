using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Enums;

namespace AXX_poc_DiPaolo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOptions<List<LoginUser>> _users;
        public AccountController(IOptions<List<LoginUser>> users)
        {
            _users = users;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostLogin(LoginUser userToLogin)
        {
            var user = _users.Value.Find(c => c.Username == userToLogin.Username && c.Password == userToLogin.Password);
            
            if (!(user is null))
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userToLogin.Username),
                    //new Claim("FullName", userToLogin.Username),
                    new Claim(ClaimTypes.Role, userToLogin.Role.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties());

               
                switch (user.Role)
                {
                    case UserRole.TyreDealer:
                        return RedirectToAction("Index", "TyreDealer");
                    case UserRole.Transporter:
                        return RedirectToAction("Index", "Transporter");
                    case UserRole.BackOffice:
                        return RedirectToAction("Index", "BackOffice");
                    default:
                        return RedirectToAction("Login");
                }

            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> PostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
