using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stajOdevPartial.Controllers
{
    public class portfolioController : Controller
    {
        // GET: portfolio
        public ActionResult Index()
        {
            return View();
        }
    }
}