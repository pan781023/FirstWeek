using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWeek.Models;

namespace FirstWeek.Controllers
{
    public class ViewController : Controller
    {
		客戶資料Entities DB = new 客戶資料Entities();
        // GET: View
        public ActionResult Index()
        {
			return View(DB.CoustomView.ToList());
        }
    }
}