using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Http;

namespace OpenWork.Services.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class AllowedFilesAttribute : ValidationAttribute
{
	private readonly string[] _extensions;
	public AllowedFilesAttribute(string[] extensions)
	{
		_extensions = extensions;
	}
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		IFormFile? file = value as IFormFile;
		if(file is not null)
		{
			string extension = Path.GetExtension(file.FileName);
			if(_extensions.Contains(extension.ToLower()))
				return ValidationResult.Success;
			else
				return new ValidationResult("This file extension is not supperted!");
		}
		else
			return ValidationResult.Success;
	}
}
