using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeek.Models
{

	[MetadataType(typeof(客戶資料Partial))]

	public partial class 客戶資料
	{
		public class 客戶資料Partial
		{
			public int Id { get; set; }
			[Required]
			[MinLength(3)]
			public string 客戶名稱 { get; set; }
			[Required]
			[MaxLength(8)]
			public string 統一編號 { get; set; }
			[Required]
			[MaxLength(10)]
			public string 電話 { get; set; }
			[Required]
			[MaxLength(10)]
			public string 傳真 { get; set; }
			[Required]
			public string 地址 { get; set; }
			[Required]
			[EmailAddress]
			public string Email { get; set; }

		}
	}

}
