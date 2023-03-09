using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenWork.Services.Attributes;

public class EmailAttribute : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if(value is null)
			return new ValidationResult("Email can not be null!");
		Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

		if(!regex.Match(value.ToString()!).Success)
			return new ValidationResult("Enter correct email!");
		int[] parts = value.ToString().Split("@").Select(x => x.Length).ToArray();
		if (parts[0] + parts[1] > 256)
			return new ValidationResult("Max length 256"); 
		if(parts[0] > 64)
			return new ValidationResult("Local part max length 64");
		if(parts[1] > 255)
			return new ValidationResult("Domain part max length 255");
		return ValidationResult.Success;
	}
}
