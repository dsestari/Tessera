using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tessera.Repositories;
using Tessera.Utilities;

namespace Tessera.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //remember password
            //var pass = Helper.Decode("aGVscDF0ZXNzZXJh");            
            
            if (User.Identity.Name == ""  || User.Identity.Name == null)
            {
               return RedirectToAction("Login","Users");
            }
            
            if (Session["UserId"] == null)
            {
                var userName = User.Identity.Name;

                UserRepository uRep = new UserRepository();

                var user = uRep.GetUserByName(userName);

                Session["UserId"] = user.Id;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}