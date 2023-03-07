using System.ComponentModel.DataAnnotations;

using OpenWork.Services.Attributes;

namespace OpenWork.Services.Dtos.Common;

public class PhoneConfirmDto
{
	[Required(ErrorMessage = "Enter phone number"), PhoneNumber(ErrorMessage = "Enter valid phone number")]
	public string Phone { get; set; } = string.Empty;
	[Required(ErrorMessage = "Enter your verification code"), ConfirmationCode(ErrorMessage = "Enter 6-digit number")]
	public int Code { get; set; }
}
