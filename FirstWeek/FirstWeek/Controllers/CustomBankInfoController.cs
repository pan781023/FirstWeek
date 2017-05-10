using FirstWeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeek.Controllers
{
    public class CustomBankInfoController : Controller
    {
        客戶資料Entities DB = new 客戶資料Entities();
        // GET: CustomBankInfo
        public ActionResult Index()
        {
            return View(DB.客戶銀行資訊.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}