using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Attributes
{
	public class ConfirmationCodeAttribute : ValidationAttribute
	{
		public override bool IsValid(object? value)
		{
			int code = (int)value;
			if (code > 99999 && code < 1_000_000)
				return true;
			return false;
		}
	}
}
