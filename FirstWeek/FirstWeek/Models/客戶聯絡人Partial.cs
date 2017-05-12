using FirstWeek.Models.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstWeek.Models
{
	[MetadataType(typeof(ContactPartial))]



	public partial class 客戶聯絡人 : IValidatableObject
	{
		客戶資料Entities DB = new 客戶資料Entities();
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var checkEmail = DB.客戶聯絡人.Where(x=>x.客戶Id == Id).Where(x => x.Email == Email).Count();
			if (checkEmail > 0)
			{
				yield return new ValidationResult("Email已存在請輸入新的email", new[] { "Email" });
			}
			//throw new NotImplementedException();
		}
	}

	public partial class 客戶聯絡人
	{
		public class ContactPartial
		{
			public int Id { get; set; }
			[Required]
			public int 客戶Id { get; set; }
			[Required]
			public string 職稱 { get; set; }
			[Required]
			[MinLength(3)]
			public string 姓名 { get; set; }
			[Required]
			[EmailAddress]
			public string Email { get; set; }
			[Required]
			[myphone(ErrorMessage = "手機需要有0912-000000格式錯誤")]
			[MaxLength(11)]
			public string 手機 { get; set; }
			[Required]
			[MaxLength(10)]
			public string 電話 { get; set; }

		}
	}
}