using OpenWork.Domain.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Dtos.Admin;
public class SphereCreateDto
{
	[Required(ErrorMessage = "Enter name of skill")]
	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	[Required(ErrorMessage = "Choose a catergory for this skill")]
	public int CategoryId { get; set; }
}
