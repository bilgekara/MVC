using Framewokr.Entites;
using Framework.Business.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Development.AlzheimerMerkezi.WebUI.Controllers
{
    public class HomeController : Controller
    {

        IUserService userService;

        public HomeController()
        {
            userService = new UserService();
        }

        // GET: Home
        public ActionResult Index()
        {
            User user = new User();
            user.FullName = "bilgeli";
            user.Email = "bilgeli";
            user.Password = "bilgeli";
            user.UserName = "bilgeli";

            bool eklendimi = userService.AddUser(user);



            return View();
        }
    }
}