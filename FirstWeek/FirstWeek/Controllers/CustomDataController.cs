using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWeek.Models;
using System.Web.Security;

namespace FirstWeek.Controllers
{
	[Authorize]
	public class CustomDataController : Controller
    {
        客戶資料Entities DB = new 客戶資料Entities();
		// GET: CustomData
		
		public ActionResult Index(string SearchString)
        {
			var data = from u in DB.客戶資料 where u.isDeleted ==false select u;
			if (SearchString !=null)
			{
				data = data.Where(x => x.客戶名稱.Contains(SearchString) || x.地址.Contains(SearchString));
			}

			return View(data.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶資料 Customer)
        {
            if (ModelState.IsValid)
            {
                var newUser = new 客戶資料();
                newUser.客戶名稱 = Customer.客戶名稱;
                newUser.統一編號 = Customer.統一編號;
                newUser.電話 = Customer.電話;
                newUser.傳真 = Customer.傳真;
                newUser.地址 = Customer.地址;
                newUser.Email = Customer.Email;
                DB.客戶資料.Add(newUser);
                try
                {
                    DB.SaveChanges();
                }
                catch (Exception ex )
                {

                    throw ex;
                }
                
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var Data = DB.客戶資料.Where(x => x.Id == id).FirstOrDefault();
            return View(Data);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteOK(int id)
        {
			//DB.客戶資料.Remove(DB.客戶資料.Find(id));
			var Data = DB.客戶資料.Where(x => x.Id == id).FirstOrDefault();
			Data.isDeleted = true;
			Data.客戶聯絡人.Where(x => x.客戶Id == id).FirstOrDefault().isDeleted = true;
			Data.客戶銀行資訊.Where(x => x.客戶Id == id).FirstOrDefault().isDeleted = true;
			//var Data2 = DB.客戶聯絡人.Where(x => x.Id == id).FirstOrDefault();
			//Data2.isDeleted = true;
			//var Data3 = DB.客戶聯絡人.Where(x => x.Id == id).FirstOrDefault();
			//Data3.isDeleted = true;
			try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
            
        }
        public ActionResult Details(int id)
        {
           var Data = DB.客戶資料.Where(x => x.Id == id).FirstOrDefault();
            return View(Data);
        }
        public ActionResult Edit(int id)
        {
            var Data = DB.客戶資料.Where(x => x.Id == id).FirstOrDefault();
            return View(Data);
        }
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditUpdate(int id, 客戶資料 Customer )
        {
            var Data = DB.客戶資料.Where(x => x.Id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                Data.客戶名稱 = Customer.客戶名稱;
                Data.統一編號 = Customer.統一編號;
                Data.電話 = Customer.電話;
                Data.傳真 = Customer.傳真;
                Data.地址 = Customer.地址;
                Data.Email = Customer.Email;
				try
				{
					DB.SaveChanges();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				return RedirectToAction("Index");
				
            }
            return View(Customer);
        }
		
		
    }
}