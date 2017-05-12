using FirstWeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeek.Controllers
{
	[Authorize]
	public class CustomContactController : Controller
    {
        客戶資料Entities DB = new 客戶資料Entities();
        // GET: CustomContact
        public ActionResult Index(string SearchString)
        {
			var Data = from u in DB.客戶聯絡人
					   where u.客戶資料.isDeleted == false
					   where u.isDeleted == false
					   select u;
			if (SearchString !=null)
			{
				Data = Data.Where(x => x.姓名.Contains(SearchString) || x.手機.Contains(SearchString)|| x.客戶資料.客戶名稱.Contains(SearchString));
			}

			return View(Data.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, 客戶聯絡人 Custom)
        {
			if (ModelState.IsValid)
			{
				var newCustom = new 客戶聯絡人();
				newCustom.客戶Id = id;
				newCustom.職稱 = Custom.職稱;
				newCustom.姓名 = Custom.姓名;
				newCustom.Email = Custom.Email;
				newCustom.手機 = Custom.手機;
				newCustom.電話 = Custom.電話;
				DB.客戶聯絡人.Add(newCustom);
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
			return View(Custom);
        }
		public ActionResult Delete(int id)
		{
			var Data = DB.客戶聯絡人.Where(x => x.Id == id).FirstOrDefault();
			return View(Data);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteOK(int id)
		{
			//DB.客戶聯絡人.Remove(DB.客戶聯絡人.Find(id));
			var Data = DB.客戶聯絡人.Where(x => x.Id == id).FirstOrDefault();
			Data.isDeleted = true;
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
			var Data = DB.客戶聯絡人.Where(x => x.Id == id).FirstOrDefault();
			return View(Data);
		}
		public ActionResult Edit(int id)
		{
			var Data = DB.客戶聯絡人.Where(x => x.Id == id).FirstOrDefault();
			return View(Data);
		}
		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public ActionResult EditUpdate(int id, 客戶聯絡人 CustomerContact)
		{
			var Data = DB.客戶聯絡人.Where(x => x.Id == id).FirstOrDefault();
			if (ModelState.IsValid)
			{
				Data.職稱 = CustomerContact.職稱;
				Data.姓名 = CustomerContact.姓名;
				Data.手機 = CustomerContact.手機;
				Data.電話 = CustomerContact.電話;
				Data.Email = CustomerContact.Email;
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
			return View(CustomerContact);
		}
	}
}