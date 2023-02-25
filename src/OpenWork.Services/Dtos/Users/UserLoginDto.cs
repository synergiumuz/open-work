using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Attributes;

namespace OpenWork.Services.Dtos.Users;

public class UserLoginDto
{
	[Required(ErrorMessage = "Enter email"), Email(ErrorMessage = "Enter valid email")]
	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter password"), MaxLength(16, ErrorMessage = "Max Length 16"), MinLength(8, ErrorMessage = "Min Length 8")]

	public string Password { get; set; } = string.Empty;
}
