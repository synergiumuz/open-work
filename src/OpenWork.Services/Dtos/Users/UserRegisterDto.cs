using System.ComponentModel.DataAnnotations;

using OpenWork.Domain.Entities;
using OpenWork.Services.Attributes;

namespace OpenWork.Services.Dtos.Users;

public class UserRegisterDto
{

	[Required(ErrorMessage = "Enter name")]

	public string Name { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter surname")]

	public string SurName { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter email"), Email(ErrorMessage = "Enter valid email")]

	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter password"), MinLength(8, ErrorMessage = "Minimum length is 8"), MaxLength(16, ErrorMessage = "Maximum length is 16"), StrongPassword(ErrorMessage = "Password should contain 1 uppercase, 1 lowercase, 1 number and 1 symbol at minimum")]

	public string Password { get; set; } = string.Empty;

	public static implicit operator User(UserRegisterDto userDto)
	{
		return new User()
		{
			Email = userDto.Email,
			Surname = userDto.SurName,
			Name = userDto.Name,
		};
	}
}
