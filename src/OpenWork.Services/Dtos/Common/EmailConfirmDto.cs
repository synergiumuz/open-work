using OpenWork.Services.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Dtos.Common
{
	public class EmailConfirmDto
	{
		[Required(ErrorMessage ="Email required"),Email(ErrorMessage ="Enter valid email")]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = "Enter your verification code"), ConfirmationCode(ErrorMessage = "Enter 6-digit number")]
		public int Code { get; set; }

	}
}
