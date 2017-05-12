using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FirstWeek.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
		public ActionResult Logout()
		{
			//清除Session中的資料
			Session.Abandon();
			//登出表單驗證
			FormsAuthentication.SignOut();
			//導至登入頁
			return RedirectToAction("Login", "Home");
		}
		public ActionResult Login() {
			return View();
		}
		[HttpPost]
		public ActionResult Login(string account, string password)
		{
			if (account == "amber" && password == "amber")
			{
				FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
					account
					, DateTime.Now
					, DateTime.Now.AddMinutes(30)
					, true
					, "userdata"
					, FormsAuthentication.FormsCookiePath);
				string enTicket = FormsAuthentication.Encrypt(ticket);
				var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enTicket);
				cookie.HttpOnly = true;
				Response.Cookies.Add(cookie);
				return RedirectToAction("Index", "Home");
			}

			return Content("登入錯誤，請輸入正確帳號密碼");

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