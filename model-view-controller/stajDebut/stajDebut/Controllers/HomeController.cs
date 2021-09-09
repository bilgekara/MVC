using stajDebut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stajDebut.Controllers
{
    public class HomeController : Controller
    {
        VeritabaniBaglantisi baglanti = new VeritabaniBaglantisi();
        // GET: Home
        public ActionResult Index()
        {
            List<Menu> menus = baglanti.Menus.ToList();

            return View(menus);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Kullanici user)
        {
            baglanti.Kullanicis.Add(user);
            baglanti.SaveChanges();
            return View();
        }
    }
}