using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Dtos
{
	public class UserLoginDto
	{
		[Required, Email]
		public string Email { get; set; } = string.Empty;

		[Required,MaxLength(16, ErrorMessage ="Max Length 16"),MinLength(8,ErrorMessage ="Min Length 8")]

		public string Password { get; set; } = string.Empty;
	}
}
