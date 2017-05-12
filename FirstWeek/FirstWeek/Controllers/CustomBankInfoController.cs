using FirstWeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeek.Controllers
{
	[Authorize]
	public class CustomBankInfoController : Controller
    {
        客戶資料Entities DB = new 客戶資料Entities();
        // GET: CustomBankInfo

        public ActionResult Index(string SearchString)
        {
			var data = from u in DB.客戶銀行資訊
					   where u.客戶資料.isDeleted == false
					   where u.isDeleted == false
					   select u;
			if (SearchString != null)
			{
				data = data.Where(x => x.帳戶名稱.Contains(SearchString) || x.帳戶號碼.Contains(SearchString) || x.銀行名稱.Contains(SearchString));
			}
            return View(data.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(int id, 客戶銀行資訊 Bankinfo)
		{
			if (ModelState.IsValid)
			{
				var newInfo = new 客戶銀行資訊();
				newInfo.客戶Id = id;
				newInfo.銀行名稱 = Bankinfo.銀行名稱;
				newInfo.銀行代碼 = Bankinfo.銀行代碼;
				newInfo.分行代碼 = Bankinfo.分行代碼;
				newInfo.帳戶名稱 = Bankinfo.帳戶名稱;
				newInfo.帳戶號碼 = Bankinfo.帳戶號碼;
				DB.客戶銀行資訊.Add(newInfo);
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
			return View(Bankinfo);
		}
		public ActionResult Delete(int id)
		{
			var Data = DB.客戶銀行資訊.Where(x => x.Id == id).FirstOrDefault();
			return View(Data);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteOK(int id)
		{
			var Data = DB.客戶銀行資訊.Where(x => x.Id == id).FirstOrDefault();
			Data.isDeleted = true;
			//DB.客戶銀行資訊.Remove(DB.客戶銀行資訊.Find(id));
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
		public ActionResult Edit(int id)
		{
			var Data = DB.客戶銀行資訊.Where(x => x.Id == id).FirstOrDefault();
			return View(Data);
		}
		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public ActionResult EditUpdate(int id, 客戶銀行資訊 Bankinfo)
		{
			var Data = DB.客戶銀行資訊.Where(x => x.Id == id).FirstOrDefault();
			if (ModelState.IsValid)
			{
				//Data.客戶Id = customID;
				Data.銀行名稱 = Bankinfo.銀行名稱;
				Data.銀行代碼 = Bankinfo.銀行代碼;
				Data.分行代碼 = Bankinfo.分行代碼;
				Data.帳戶名稱 = Bankinfo.帳戶名稱;
				Data.帳戶號碼 = Bankinfo.帳戶號碼;
				
				DB.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(Bankinfo);
		}
		public ActionResult Details(int id)
		{
			var Data = DB.客戶銀行資訊.Where(x => x.Id == id).FirstOrDefault();
			return View(Data);
		}
	}
}