using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stajOdevPartial.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        #region PARTİAL
        [HttpGet]
        public ActionResult home()
        {
            return PartialView("~/Views/Home/Partial/_home.cshtml");
        } 
        #endregion
    }
}