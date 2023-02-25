using System;
using System.ComponentModel.DataAnnotations;

namespace OpenWork.Services.Dtos.Workers;

public class BusynessCreateDto
{
	[Required(ErrorMessage = "Choose start date")]
	public DateTime Start { get; set; }

	[Required(ErrorMessage = "Choose end date")]
	public DateTime End { get; set; }
}
