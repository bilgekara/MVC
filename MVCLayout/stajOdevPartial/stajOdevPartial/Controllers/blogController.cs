using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stajOdevPartial.Controllers
{
    public class blogController : Controller
    {
        // GET: blog
        public ActionResult Index()
        {
            return View();
        }
    }
}