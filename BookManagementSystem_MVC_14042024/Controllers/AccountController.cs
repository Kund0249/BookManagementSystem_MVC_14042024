using BookManagementSystem_MVC_14042024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookManagementSystem_MVC_14042024.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserRepository repository;
        public AccountController()
        {
            repository = new UserRepository();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {

            //if
            //  (
            //    (UserName == "abhishek" && Password == "123456") ||
            //    (UserName == "vishal" && Password == "123456") ||
            //    (UserName == "vaishali" && Password == "123456")
            //  )
            //{
            //    FormsAuthentication.RedirectFromLoginPage(UserName, false);
            //}
            if (repository.IsValidUser(UserName, Password))
            {
                FormsAuthentication.RedirectFromLoginPage(UserName, false);
            }
            Notify("Invalid Credentials", "Incorrect username or password!", NotificationType.error);
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(Login));
        }

    }
}