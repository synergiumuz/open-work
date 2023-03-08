using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

using OpenWork.Domain.Entities;
using OpenWork.Services.Attributes;

namespace OpenWork.Services.Dtos.Workers;

public class WorkerRegisterDto
{
	[Required(ErrorMessage = "Enter name"),MinLength(2), MaxLength(20),Name]
	public string Name { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter surname"), MinLength(2), MaxLength(30)]
	public string Surname { get; set; } = string.Empty;

	[Required(ErrorMessage = "Enter email"), Email(ErrorMessage = "Enter valid email")]
	public string Email { get; set; } = string.Empty;

	public string Phone { get; set; } = string.Empty;

	[Required, MaxLength(16, ErrorMessage = "Max Length 16"), MinLength(8, ErrorMessage = "Min Length 8"), StrongPassword(ErrorMessage = "Password should contain 1 capital, 1 lower, 1 number and 1 symbol at less")]
	public string Password { get; set; } = string.Empty;

	public IFormFile? Image { get; set; }

	public static implicit operator Worker(WorkerRegisterDto workerDto)
	{
		return new Worker()
		{
			Email = workerDto.Email,
			Phone = workerDto.Phone,
			Name = workerDto.Name,
			CreatedAt = DateTime.Now,
			LastSeen = DateTime.Now,
			Surname = workerDto.Surname,
		};
	}
}

