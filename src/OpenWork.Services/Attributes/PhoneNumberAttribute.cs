﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OpenWork.Services.Attributes;

public class PhoneNumberAttribute : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if(value == null || string.IsNullOrEmpty(value?.ToString()))
			return ValidationResult.Success;

		Regex regex = new Regex("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$");

		return regex.Match(value?.ToString()!).Success ? ValidationResult.Success
			: new ValidationResult("Please enter valid phone number. Phone must be contains only numbers or + character");
	}
}
