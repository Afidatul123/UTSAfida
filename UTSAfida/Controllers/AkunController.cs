using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UTSAfida.Data;
using UTSAfida.Models;

namespace UTSAfida.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;
        public AkunController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User data)
        {
            var deklarrole = _context.Tb_Roles.Where(x => x.Id == "2").FirstOrDefault();

            data.Roles = deklarrole;

            _context.Tb_User.Add(data);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User data)
        {
            var cari = _context.Tb_User.Where(
                                            bebas =>
                                            bebas.Username == data.Username
                                            &&
                                            bebas.Password == data.Password
                                            ).FirstOrDefault();

            var cariusername = _context.Tb_User.Where(
                                            bebas =>
                                            bebas.Username == data.Username
                                            ).FirstOrDefault();

            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where(
                                            bebas =>
                                            bebas.Username == data.Username
                                            &&
                                            bebas.Password == data.Password
                                            )
                    .Include(bebas2 => bebas2.Roles)
                    .FirstOrDefault();

                if(cekpassword != null)
                {
                    var regis = new List<Claim>
                    {
                        new Claim("Username", cariusername.Username),
                        new Claim("Roles", cariusername.Roles.Id),
                    };

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(regis, "Cookies", "Username", "Role")
                        )
                    );

                    if (cariusername.Roles.Id == "1")
                    {
                        return RedirectToAction(controllerName: "Jadwal", actionName: "Index");
                    }
                    else if (cariusername.Roles.Id == "2")
                    {
                        return RedirectToAction(controllerName: "Home", actionName: "Users");
                    }
                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }
                ViewBag.pesan = "Password salah";
                return View(data);
            }
            ViewBag.pesan = "Username tidak terdaftar";
            return View(data);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
