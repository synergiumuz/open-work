﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenWork.Services.Attributes
{
    public class NameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return new ValidationResult("Name can not be null!");
            Regex regex = new Regex("^[a-zA-Z]*$");

            if (regex.Match(value.ToString()!).Success)
                return ValidationResult.Success;

            return new ValidationResult("Wrong name entered");
        }
    }
}
