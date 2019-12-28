using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalR_UserControl.Hubs;
using SignalR_UserControl.Models;
using System.Net;
namespace SignalR_UserControl.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verify(user acc)
        {
            using (loginDB db = new loginDB())
            {
                var userDetail = db.user.Where(x => x.userName == acc.userName && x.userPassword==acc.userPassword).FirstOrDefault();
                if(userDetail==null)
                {
                    acc.LoginErrorMessage = "Kullanıcı adı/parolanızı kontrol ediniz";
                    return View("Login",acc);
                }
                else
                {
                    Session["userID"] = acc.userID;
                    Session["userName"] = acc.userName;
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login","Account");
        }
    }
}