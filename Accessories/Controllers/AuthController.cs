using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accessories.Models;
using System.Web.Security;

namespace Accessories.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        DB DB = new DB();
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string UserName,string Password,string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                if(DB.Users.Any(x=>x.UserName==UserName&&x.Password==Password))
                {
                    FormsAuthentication.SetAuthCookie(UserName, false);
                    if(ReturnUrl!=null&&Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Users");
                    }
                }
                else
                {
                    ViewBag.error = "User Name And Password Is Not Valid !!";
                }
            }
            return View();
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }
    }
}