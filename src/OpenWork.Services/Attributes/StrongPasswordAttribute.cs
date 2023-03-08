using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OpenWork.Services.Attributes;

public class StrongPasswordAttribute : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if(value is null)
			return new ValidationResult("Password can not be null!");
		else
		{
			string password = value.ToString()!;
			if(password.Length < 8)
				return new ValidationResult("Password must be at least 8 characters!");
			if(password.Length > 16)
				return new ValidationResult("Password must be less than 16 characters!");

			(bool IsValid, string Message) result = IsStrong(password);

			if(result.IsValid is false)
				return new ValidationResult(result.Message);

			return ValidationResult.Success;
		}
	}
	public (bool IsValid, string Message) IsStrong(string password)
	{
		bool isDigit = password.Any(x => char.IsDigit(x));
		bool isLower = password.Any(x => char.IsLower(x));
		bool isUpper = password.Any(x => char.IsUpper(x));
		bool isSpace = password.Any(x => char.IsWhiteSpace(x));
		if(!isLower)
			return (IsValid: false, Message: "Password must be at least one lower letter!");
		if(!isUpper)
			return (IsValid: false, Message: "Password must be at least one upper letter!");
		if(!isDigit)
			return (IsValid: false, Message: "Password must be at least one digit!");
		if(isSpace)
			return (IsValid: false, Message: "Password does not contain with spaces!");


		return (IsValid: true, Message: "Password is strong");
	}
}
