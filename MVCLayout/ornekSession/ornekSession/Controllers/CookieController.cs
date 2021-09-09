using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ornekSession.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("yeniCookie","Bilgenur Kara");
            cookie.Expires = DateTime.Now.AddHours(3);
            Response.Cookies.Add(cookie);
            return View();
        }
        public ActionResult Cookie()
        {

            ViewBag.CookieVerisi = Request.Cookies["yeniCookie"].Value;
            
            return View();
        }
    }
}