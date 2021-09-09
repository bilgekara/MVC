using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalay.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hakkimda()
        {
            return View();
        }

        #region PARTIAL
        public ActionResult _Slider()
        {
            return PartialView("~/Views/Anasayfa/Partial/_Slider.cshtml");
        }
        #endregion

        


    }
}