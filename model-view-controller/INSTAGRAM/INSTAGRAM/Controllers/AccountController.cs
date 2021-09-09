using INSTAGRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSTAGRAM.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string PhoneOrEmail, string Password)
        {
            InstagramBaglantisi baglantisi = new InstagramBaglantisi();

            User user = baglantisi.Users.Where(x => 
                                                  (x.Email == PhoneOrEmail || x.Phone == PhoneOrEmail) && 
                                                  x.Password == Password)
                                                  .ToList()
                                                  .FirstOrDefault();

            if (user != null)
            {
                HttpCookie cookie = new HttpCookie("authentication", user.FullName);

                cookie.Expires = DateTime.Now.AddDays(10);

                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Phone, string FullName, string Email, string UserName, string Password)
        {
            InstagramBaglantisi baglanti = new InstagramBaglantisi();

            User user = new User();

            user.Email = Email;

            user.Phone = Phone;

            user.UserName = UserName;

            user.Password = Password;

            user.FullName = FullName;

            baglanti.Users.Add(user);

            baglanti.SaveChanges();

            return View();
        }
    }
}