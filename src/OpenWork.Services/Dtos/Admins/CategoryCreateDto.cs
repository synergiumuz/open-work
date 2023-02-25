using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Dtos.Admin;

public class CategoryDto
{
	[Required(ErrorMessage = "Enter category name")]
	public string Name { get; set; } = string.Empty;
}
