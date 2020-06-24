using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tessera.Models;
using Tessera.Repositories;
using Tessera.Utilities;
using Tessera.ViewModels;
using System.Data.Entity;

namespace Tessera.Controllers
{
    public class UsersController : Controller
    {               
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var userViewModelRep = new UserViewModelRepository();

            return View("UserForm", userViewModelRep.GetNewUserGroupAndStatus());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var userViewModelRep = new UserViewModelRepository();

                return View("UserForm", userViewModelRep.GetUserGroupAndStatus(user));
            }

            var userRep = new UserRepository();

            userRep.PersistUser(user);

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Edit(int id)
        {
            var userRep = new UserRepository();

            var user = userRep.GetUserById(id);

            if (user == null)
                return HttpNotFound();

            var userViewModelRep = new UserViewModelRepository();

            return View("UserForm", userViewModelRep.GetUserGroupAndStatusForEdit(user));
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if ((email != null && password != null) && (email != "" && password != ""))
                {
                    var userRep = new UserRepository();

                    var authentication = userRep.Login(email, password);

                    if (authentication.Select(a => a.authReturn).First() == true)
                    {
                        Session["UserId"] = authentication.Select(a => a.message).First();
                        string returnUrl = Request.QueryString["ReturnUrl"];

                        if (returnUrl != null)
                            return Redirect(returnUrl);
                        else
                            return RedirectToAction("Index", "Tickets");
                    }
                    else
                    {
                        ViewBag.Message = authentication.Select(a => a.message).First();
                        return View();
                    }
                }
                else
                    ViewBag.Message = "Incorret email or password";
                return View();
            }
            catch (Exception ex)
            {
                var userLog = new UserLog();
                userLog.Description = ex.Message;
                userLog.DataLog = DateTime.Now;
                userLog.Username = email;

                UserLogRepository.InsertUserLog(userLog);

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string email, string currentPassword, string newPassword)
        {
            if ((email != null && currentPassword != null && newPassword != null) && (email != "" && currentPassword != "" && newPassword != ""))
            {
                var userRep = new UserRepository();

                var changed = userRep.ChangePassword(email, currentPassword, newPassword);

                if (changed == true)
                {
                    return RedirectToAction("Login", "Users");
                }
                else
                    ViewBag.Message = "Incorrect credentials";

                return View();
            }
            else
                ViewBag.Message = "Incorrect credentials";

            return View();
        }

        [AllowAnonymous]
        public ActionResult RememberPass()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RememberPass(string email)
        {
            if (email != null && email != "")
            {
                var userRep = new UserRepository();
                var sent = userRep.CheckEmail(email);

                if (sent == true)
                {                    
                    ViewBag.Message = "E-mail sent with success.";
                }
                else
                    ViewBag.Message = "E-mail not found.";
            }
            else
                ViewBag.Message = "E=mail invalid.";

            return View();
        }
    }
}