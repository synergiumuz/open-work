using System.ComponentModel.DataAnnotations;

namespace OpenWork.Services.Dtos.Admins;

public class CategoryDto
{
	[Required(ErrorMessage = "Enter category name")]
	public string Name { get; set; } = string.Empty;
}
