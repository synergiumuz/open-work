using System.ComponentModel.DataAnnotations;

namespace OpenWork.Services.Dtos.Admins;
public class SkillCreateDto
{
	[Required(ErrorMessage = "Enter name of skill")]
	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	[Required(ErrorMessage = "Choose a catergory for this skill")]
	public int CategoryId { get; set; }
}
