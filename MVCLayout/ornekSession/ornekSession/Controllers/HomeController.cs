using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ornekSession.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["yeniSession"] = "Session";
            ViewBag.yeni = Session["yeniSession"].ToString();
            return View();
        }
    }
}