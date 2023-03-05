using OpenWork.Domain.Entities;
using OpenWork.Services.Dtos.Users;
using System.ComponentModel.DataAnnotations;

namespace OpenWork.Services.Dtos.Admins;

public class CategoryCreateDto
{
	[Required(ErrorMessage = "Enter category name")]
	public string Name { get; set; } = string.Empty;

	public static implicit operator Category(CategoryCreateDto categoryDto)
	{
		return new Category()
		{
			Name = categoryDto.Name
		};
	}
}
