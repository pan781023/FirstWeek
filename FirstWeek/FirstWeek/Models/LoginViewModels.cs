using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace FirstWeek.Models
{
	public class LoginViewModels
	{
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ReturnUrl { get; set; }
		[Required]
		[Display(Name ="帳號")]
		public string account { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "密碼")]
		public string password { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			
			if (!(account == "amber" && password != "amber"))
			{
				yield return new ValidationResult("無此帳號或密碼", new string[] { "account" });
			}
		}
	}
}