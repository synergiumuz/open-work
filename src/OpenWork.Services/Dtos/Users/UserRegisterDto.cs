using System.ComponentModel.DataAnnotations;

using OpenWork.Domain.Entities;
using OpenWork.Services.Attributes;

namespace OpenWork.Services.Dtos.Users;

public class UserRegisterDto
{

	[Required(ErrorMessage = "Enter name"),MinLength(2),MaxLength(20)]

	public string Name { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter surname"),MinLength(2), MaxLength(30)]

	public string Surname { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter email"), Email(ErrorMessage = "Enter valid email"),]

	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter password"), MinLength(8, ErrorMessage = "Minimum length is 8"), MaxLength(16, ErrorMessage = "Maximum length is 16"), StrongPassword(ErrorMessage = "Password should contain 1 uppercase, 1 lowercase and 1 number at minimum")]

	public string Password { get; set; } = string.Empty;

	public static implicit operator User(UserRegisterDto userDto)
	{
		return new User()
		{
			Email = userDto.Email,
			Surname = userDto.Surname,
			Name = userDto.Name,
		};
	}
}
