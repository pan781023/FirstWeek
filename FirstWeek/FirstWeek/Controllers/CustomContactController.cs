using FirstWeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeek.Controllers
{
    public class CustomContactController : Controller
    {
        客戶資料Entities DB = new 客戶資料Entities();
        // GET: CustomContact
        public ActionResult Index()
        {
            return View(DB.客戶聯絡人.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶聯絡人 Custom)
        {
            var newCustom = new 客戶聯絡人();
            
           
            //newCustom.職稱 = Custom.職稱;
            //newCustom.姓名 = Custom.姓名;
            //newCustom.Email = Custom.Email;
            //newCustom.手機 = Custom.手機;
            //newCustom.電話 = Custom.電話;
            //DB.客戶聯絡人.Add(newCustom);
            //DB.SaveChanges();
            return RedirectToAction("Index");
        }
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