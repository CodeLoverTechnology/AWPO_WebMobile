using AWPO_WebMobile.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWPO_WebMobile.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            if (!CommonFunctions.CheckUserAuthentication())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_post(FormCollection formCollection)
        {
            ViewBag.Message = "";
            string username = formCollection["username"].ToString();
            string password = formCollection["password"].ToString();
            if(username==Resources.AWPOResources.AdminUserID && password ==Resources.AWPOResources.AdminPwd)
            {
                Session["PrCode"] = username;
                Session["PrName"] = username;
                return RedirectToAction("Dashboard");
            }
            ViewBag.Message = "Login ID and Password not Matched.. Try Again!...";
            return View();
        }

        public ActionResult D2cLogOut()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            Session["PrCode"] = null;
            Session["PrName"] = null;
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
    }
}