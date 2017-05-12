using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FirstWeek.Models.Validate
{
	public class myphoneAttribute : ValidationAttribute 
	{

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			//return base.IsValid(value, validationContext);
			var str = (string)value;

			if (Regex.IsMatch(str, @"\d{4}-\d{6}")==false)
			{
				var errormessage = FormatErrorMessage(validationContext.DisplayName);
				return new ValidationResult(errormessage);
			}
			else
			{
				return ValidationResult.Success;
			}
		}
		
		
	}
}