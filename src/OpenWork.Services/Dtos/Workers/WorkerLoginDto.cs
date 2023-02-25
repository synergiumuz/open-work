using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenWork.Services.Attributes;

namespace OpenWork.Services.Dtos.Worker;

public class WorkerLoginDto
{
	[Required(ErrorMessage = "Enter email"), Email(ErrorMessage = "Enter valid email")]
	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter email"), MinLength(8, ErrorMessage = "Minimum length is 8"), MaxLength(16, ErrorMessage = "Max length is 16")]
	public string Password { get; set; } = string.Empty;
}
