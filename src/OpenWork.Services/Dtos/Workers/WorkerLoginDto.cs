using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Attributes;

namespace OpenWork.Services.Dtos.Workers;

public class WorkerLoginDto
{
	[Required(ErrorMessage = "Enter email"), Email(ErrorMessage = "Enter valid email")]
	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter email"), MinLength(8, ErrorMessage = "Minimum length is 8"), MaxLength(16, ErrorMessage = "Max length is 16")]
	public string Password { get; set; } = string.Empty;
}
